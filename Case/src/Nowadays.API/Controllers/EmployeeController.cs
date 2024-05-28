using AutoMapper;
using IdentityService;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Application.Models.Employee;
using Nowadays.Application.Models.Project;
using Nowadays.Application.Services;
using Nowadays.Core.Entities;
using Nowadays.Core.ValueObject;

namespace Nowadays.API.Controllers
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
        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            var employeeList = await _employeeService.GetAll();
            return employeeList;
        }
        [HttpGet("{id}")]
        public async Task<Employee> GetEmployee(string id)
        {
            var employee = await _employeeService.GetById(id);
            return employee;
        }
        [HttpPost]
        public async Task<Employee> CreateEmployee([FromBody] EmployeeDTO employee)
        {
            var employeeModel = _mapper.Map<Employee>(employee);
            bool result = await IdentityVerification(employee);
            var response = await _employeeService.InsertAsync(employeeModel, result);
            return response;
        }
        [HttpPut]
        public async Task<ProjectEmployee> AssingEmployeeToProject([FromBody] ProjectEmployeeDTO projectEmployee)
        {
            var projectEmployeeModel = _mapper.Map<ProjectEmployee>(projectEmployee);
            var response = await _employeeService.AssignEmployeeToProject(projectEmployeeModel);
            return response;
        }
        [HttpPut("{id}")]
        public async Task<Employee> AssingEmployeeToProject(string id,[FromBody] EmployeeSettingDTO employee)
        {
            var projectEmployeeModel = _mapper.Map<Employee>(employee);
            var response = await _employeeService.UpdateEmployeeSettingAsync(id,projectEmployeeModel);
            return response;
        }
        [HttpDelete("{id}")]
        public async Task<Employee> DeleteEmployee(string id)
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
