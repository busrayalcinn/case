using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Models;
using Nowadays.Models.DTOs;
using Nowadays.Models.ResponseModels;
using Nowadays.Services.Abstract;

namespace Nowadays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ResponseModel<IEnumerable<Company>>> GetAllCompany()
        {
            var companyList = await _companyService.GetAll();
            return companyList;
        }
        [HttpGet("{id}")]
        public async Task<ResponseModel<Company>> GetCompany(string id)
        {
            var company = await _companyService.GetCompanyById(id);
            return company;
        }
        [HttpPost]
        public async Task<ResponseModel> CreateCompany([FromBody]CompanyDTO company)
        {
            var companyModel = _mapper.Map<Company>(company);
            var response = await _companyService.InsertAsync(companyModel);
            return response;
        }
        [HttpPut("{id}")]
        public async Task<ResponseModel> UpdateCompanyName(string id, [FromBody]string name)
        {
            var response = await _companyService.UpdateCompanyNameAsync(id,name);
            return response;
        }
        [HttpDelete("{id}")]
        public async Task<ResponseModel> DeleteCompany(string id)
        {
            var response = await _companyService.DeleteAsync(id);
            return response;
        }
    }
}
