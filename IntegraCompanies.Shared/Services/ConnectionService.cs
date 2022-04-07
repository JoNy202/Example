using AutoMapper;
using IntegraCompanies.Data;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegraCompanies.Shared.Services
{
    public class ConnectionService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public ConnectionService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Connection>> GetAllConnection()
        {
            return await _context.Connection
                .Include(x => x.ConnectionServer)
                .OrderBy(x => x.DatabaseName)
                .ToListAsync();
        }

        public async Task<List<ConnectionGrid>> GetConnectionGridData()
        {
            var connections = await GetAllConnection();
            return _mapper.Map<List<Connection>, List<ConnectionGrid>>(connections);
        }

        public async Task<List<ConnectionCombo>> GetConnectionComboData()
        {
            var connections = await GetAllConnection();
            return _mapper.Map<List<Connection>, List<ConnectionCombo>>(connections);
        }

        public ConnectionGrid GetConnectionGrid(Connection connection)
        {
            return _mapper.Map<Connection, ConnectionGrid>(connection);
        }

        public async Task<Connection> GetConnectionById(Guid id)
        {
            return await _context.Connection
                .Include(x => x.ConnectionServer)
                .FirstOrDefaultAsync(x => x.ConnectionId == id);
        }

        public async Task<Connection> GetSameConnection(string databaseName, Guid connectionStringId)
        {
            return await _context.Connection
                .Include(x => x.ConnectionServer)
                .FirstOrDefaultAsync(x => x.DatabaseName == databaseName && x.ConnectionServerId == connectionStringId);
        }

        public async Task<Connection> AddConnection(ConnectionModify connectionModify)
        {
            var connection = _mapper.Map<ConnectionModify, Connection>(connectionModify);

            await _context.Connection.AddAsync(connection);
            await _context.SaveChangesAsync();

            return connection;
        }

        public async Task<Connection> UpdateConnection(Guid connectionId, ConnectionModify connectionModify)
        {
            var connection = await GetConnectionById(connectionId);

            if (connection != null)
            {
                _mapper.Map(connectionModify, connection);
                _context.Connection.Update(connection);

                await _context.SaveChangesAsync();
            }
            
            return connection;
        }

        public async Task DeleteConnection(Connection connection)
        {
            _context.Connection.Remove(connection);
            await _context.SaveChangesAsync();
        }
    }
}