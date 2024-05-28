using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Models.ResponseModels;
using Nowadays.Models;
using Nowadays.Services.Abstract;
using Nowadays.Services.Concrete;
using Nowadays.Models.ValueObject;
using AutoMapper;
using Nowadays.Models.DTOs;
using IdentityService;

namespace Nowadays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ResponseModel<IEnumerable<Employee>>> GetAllEmployee()
        {
            var employeeList = await _employeeService.GetAll();
            return employeeList;
        }
        [HttpGet("{id}")]
        public async Task<ResponseModel<Employee>> GetEmployee(string id)
        {
            var employee = await _employeeService.GetById(id);
            return employee;
        }
        [HttpPost]
        public async Task<ResponseModel> CreateEmployee([FromBody] EmployeeDTO employee)
        {
            var employeeModel = _mapper.Map<Employee>(employee);
            bool result = await IdentityVerification(employee);
            var response = await _employeeService.InsertAsync(employeeModel, result);
            return response;
        }
        [HttpPut]
        public async Task<ResponseModel> AssingEmployeeToProject([FromBody] ProjectEmployeeDTO projectEmployee)
        {
            var projectEmployeeModel = _mapper.Map<ProjectEmployee>(projectEmployee);
            var response = await _employeeService.AssignEmployeeToProject(projectEmployeeModel);
            return response;
        }
        [HttpPut("{id}")]
        public async Task<ResponseModel> AssingEmployeeToProject(string id,[FromBody] EmployeeSettingDTO employee)
        {
            var projectEmployeeModel = _mapper.Map<Employee>(employee);
            var response = await _employeeService.UpdateEmployeeSettingAsync(id,projectEmployeeModel);
            return response;
        }
        [HttpDelete("{id}")]
        public async Task<ResponseModel> DeleteEmployee(string id)
        {
            var response = await _employeeService.DeleteAsync(id);
            return response;
        }

        private async Task<bool> IdentityVerification(EmployeeDTO employee)
        {
            var client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var response = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(employee.IdentityNo), employee.Name, employee.SurName, employee.BirthDateYear);
            var result = response.Body.TCKimlikNoDogrulaResult;
            return result;
        }
    }
}
