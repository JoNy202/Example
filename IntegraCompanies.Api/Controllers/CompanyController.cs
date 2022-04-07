using AutoMapper;
using IntegraCompanies.Api.Resources;
using IntegraCompanies.Data.Models;
using IntegraCompanies.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegraCompanies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly CompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ILogger<CompanyController> logger, CompanyService companyService, IMapper mapper)
        {
            _logger = logger;
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<CompanyResource>>> GetAllCompanys()
        {
            var companys = await _companyService.GetAllCompany();
            var companysResource = _mapper.Map<List<Company>, List<CompanyResource>>(companys);

            return Ok(companysResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyResource>> GetCompanyById(Guid id)
        {
            var company = await _companyService.GetCompanyById(id);
            var companyResource = _mapper.Map<Company, CompanyResource>(company);

            return Ok(companyResource);
        }
    }
}
