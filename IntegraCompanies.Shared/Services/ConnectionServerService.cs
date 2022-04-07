using AutoMapper;
using EasyEncryption;
using IntegraCompanies.Data;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegraCompanies.Shared.Services
{
    public class ConnectionServerService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _secret = "test";

        public ConnectionServerService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ConnectionServer>> GetAllConnectionServer()
        {
            return await _context.ConnectionServer.ToListAsync();
        }

        public async Task<List<ConnectionServerGrid>> GetConnectionServerGridData()
        {
            var connectionServer = await GetAllConnectionServer();
            return _mapper.Map<List<ConnectionServer>, List<ConnectionServerGrid>>(connectionServer);
        }

        public async Task<List<ConnectionServerCombo>> GetConnectionServerComboData()
        {
            var connectionStrings = await GetAllConnectionServer();
            return _mapper.Map<List<ConnectionServer>, List<ConnectionServerCombo>>(connectionStrings);
        }

        public ConnectionServerGrid GetConnectionServerGrid(ConnectionServer connectionServer)
        {
            return _mapper.Map<ConnectionServer, ConnectionServerGrid>(connectionServer);
        }

        public async Task<ConnectionServer> GetConnectionServerById(Guid id)
        {
            return await _context.ConnectionServer.FindAsync(id);
        }

        public async Task<ConnectionServer> GetSameConnectionServer(string name)
        {
            return await _context.ConnectionServer.SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<ConnectionServer> AddConnectionServer(ConnectionServerModify connectionServerModify)
        {
            var connectionServer = _mapper.Map<ConnectionServerModify, ConnectionServer>(connectionServerModify);

            if (!string.IsNullOrEmpty(connectionServerModify.Password))
                connectionServer.Password = AesThenHmac.SimpleEncryptWithPassword(connectionServerModify.Password, _secret);

            await _context.ConnectionServer.AddAsync(connectionServer);
            await _context.SaveChangesAsync();

            return connectionServer;
        }

        public async Task<ConnectionServer> UpdateConnectionServer(Guid connectionServerId, ConnectionServerModify connectionServerModify)
        {
            var connectionServer = await GetConnectionServerById(connectionServerId);

            if (connectionServer != null)
            {
                _mapper.Map(connectionServerModify, connectionServer);

                if (!string.IsNullOrEmpty(connectionServerModify.Password))
                    connectionServer.Password = AesThenHmac.SimpleEncryptWithPassword(connectionServerModify.Password, _secret);

                _context.ConnectionServer.Update(connectionServer);

                await _context.SaveChangesAsync();
            }

            return connectionServer;
        }

        public async Task DeleteConnectionServer(ConnectionServer connectionServer)
        {
            _context.ConnectionServer.Remove(connectionServer);
            await _context.SaveChangesAsync();
        }
    }
}