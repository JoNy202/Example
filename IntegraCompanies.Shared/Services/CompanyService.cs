using AutoMapper;
using IntegraCompanies.Data;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegraCompanies.Shared.Services
{
    public class CompanyService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public CompanyService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Company>> GetAllCompany()
        {
            return await _context.Company
                .Include(x => x.Connection)
                    .ThenInclude(x => x.ConnectionServer)
                .Include(x => x.JurPerson)
                .Include(x => x.CompanyMasks)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<CompanyGrid>> GetCompanyGridData()
        {
            var companys = await GetAllCompany();
            return _mapper.Map<List<Company>, List<CompanyGrid>>(companys);
        }

        public CompanyGrid GetCompanyGrid(Company company)
        {
            return _mapper.Map<Company, CompanyGrid>(company);
        }

        public async Task<Company> GetCompanyById(Guid id)
        {
            return await _context.Company
                .Include(x => x.Connection)
                    .ThenInclude(x => x.ConnectionServer)
                .Include(x => x.JurPerson)
                .Include(x => x.CompanyMasks)
                .FirstOrDefaultAsync(x => x.CompanyId == id);
        }

        public async Task<Company> GetSameCompany(string name)
        {
            return await _context.Company
                .Include(x => x.Connection)
                    .ThenInclude(x => x.ConnectionServer)
                .Include(x => x.JurPerson)
                .Include(x => x.CompanyMasks)
                .FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Company> AddCompany(CompanyModify companyModify)
        {
            var company = _mapper.Map<CompanyModify, Company>(companyModify);

            await _context.Company.AddAsync(company);
            await _context.SaveChangesAsync();

            return company;
        }

        public async Task<Company> UpdateCompany(Guid companyId, CompanyModify companyModify)
        {
            var company = await GetCompanyById(companyId);

            if (company != null)
            {
                _mapper.Map(companyModify, company);
                _context.Company.Update(company);

                await _context.SaveChangesAsync();
            }

            return company;
        }

        public async Task DeleteCompany(Company company)
        {
            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
        }
    }
}