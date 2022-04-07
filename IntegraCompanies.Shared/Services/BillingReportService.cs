using AutoMapper;
using IntegraCompanies.Data;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegraCompanies.Shared.Services
{
    public class BillingReportService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public BillingReportService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BillingReport>> GetAllBillingReport()
        {
            return await _context.BillingReport
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<BillingReportCombo>> GetBillingReportComboData()
        {
            var billingReports = await GetAllBillingReport();
            return _mapper.Map<List<BillingReport>, List<BillingReportCombo>>(billingReports);
        }
    }
}