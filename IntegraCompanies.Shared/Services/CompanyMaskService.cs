using AutoMapper;
using IntegraCompanies.Data;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegraCompanies.Shared.Services
{
    public class CompanyMaskService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public CompanyMaskService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CompanyMask>> GetAllCompanyMask(Guid companyId)
        {
            return await _context.CompanyMask
                .Where(x => x.CompanyId == companyId)
                .OrderBy(x => x.Mask)
                .ToListAsync();
        }

        public async Task<List<CompanyMaskGrid>> GetCompanyMaskGridData(Guid companyId)
        {
            var companyMasks = await GetAllCompanyMask(companyId);
            return _mapper.Map<List<CompanyMask>, List<CompanyMaskGrid>>(companyMasks);
        }

        public CompanyMaskGrid GetCompanyMaskGrid(CompanyMask companyMask)
        {
            return _mapper.Map<CompanyMask, CompanyMaskGrid>(companyMask);
        }

        public async Task<CompanyMask> GetCompanyMaskById(Guid id)
        {
            return await _context.CompanyMask.FindAsync(id);
        }

        public async Task<CompanyMask> GetSameCompanyMask(Guid companyId, string mask)
        {
            return await _context.CompanyMask.SingleOrDefaultAsync(x => x.CompanyId == companyId && x.Mask == mask);
        }

        public async Task<CompanyMask> AddCompanyMask(CompanyMaskModify companyMaskModify)
        {
            var companyMask = _mapper.Map<CompanyMaskModify, CompanyMask>(companyMaskModify);

            await _context.CompanyMask.AddAsync(companyMask);
            await _context.SaveChangesAsync();

            return companyMask;
        }

        public async Task<CompanyMask> UpdateCompanyMask(Guid companyMaskId, CompanyMaskModify companyMaskModify)
        {
            var companyMask = await GetCompanyMaskById(companyMaskId);

            if (companyMask != null)
            {
                _mapper.Map(companyMaskModify, companyMask);
                _context.CompanyMask.Update(companyMask);

                await _context.SaveChangesAsync();
            }

            return companyMask;
        }

        public async Task DeleteCompanyMask(CompanyMask companyMask)
        {
            _context.CompanyMask.Remove(companyMask);
            await _context.SaveChangesAsync();
        }
    }
}