using AutoMapper;
using IntegraCompanies.Data;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegraCompanies.Shared.Services
{
    public class SmtpServerService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public SmtpServerService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SmtpServer>> GetAllSmtpServer()
        {
            return await _context.SmtpServer
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<SmtpServerCombo>> GetSmtpServerComboData()
        {
            var SmtpServers = await GetAllSmtpServer();
            return _mapper.Map<List<SmtpServer>, List<SmtpServerCombo>>(SmtpServers);
        }
    }
}