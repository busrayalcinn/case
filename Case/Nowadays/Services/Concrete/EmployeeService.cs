using IdentityService;
using Nowadays.Models;
using Nowadays.Models.ResponseModels;
using Nowadays.Models.ValueObject;
using Nowadays.Repositories.Abstract;
using Nowadays.Repositories.Concrete;
using Nowadays.Services.Abstract;
using Nowadays.Services.Concrete.Base;
using System.Xml.Linq;

namespace Nowadays.Services.Concrete
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly IProjectEmployeeRepository _projectEmployeeRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Employee> _baseRepository;
        public EmployeeService(IUnitOfWork unitOfWork, IBaseRepository<Employee> baseRepository, IProjectEmployeeRepository projectEmployeeRepository, IEmployeeRepository employeeRepository, IProjectRepository projectRepository) : base(unitOfWork, baseRepository)
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
            _projectEmployeeRepository = projectEmployeeRepository;
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
        }
        public override async Task<ResponseModel> InsertAsync(Employee employee)
        {
            try
            {
                if (employee is null)
                {
                    throw new Exception("Model is not valid.");
                }
                var verification = IdentityVerification(employee);
                if(verification.Result == false)
                {
                    throw new Exception("Identity No. is not correct!");
                }
                var result = await _employeeRepository.InsertAsync(employee);
                await _unitOfWork.CompleteTaskAsync();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(400, ex.Message);
            }
        }
        private async Task<bool> IdentityVerification(Employee employee)
        {
            var client = new IdentityService.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var response = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(employee.IdentityNo), employee.Name, employee.SurName, employee.BirthDateYear);
            var result = response.Body.TCKimlikNoDogrulaResult;
            return result;
        }
        public async Task<ResponseModel> AssignEmployeeToProject(ProjectEmployee projectEmployee)
        {
            try
            {
                var project = await _projectRepository.GetById(projectEmployee.ProjectId);
                if (project == null)
                {
                    throw new Exception("Project is not found!");
                }
                var employee = await _employeeRepository.GetById(projectEmployee.EmployeeId);
                if (project == null)
                {
                    throw new Exception("Employee is not found!");
                }
                var result = await _projectEmployeeRepository.InsertAsync(projectEmployee);
                await _unitOfWork.CompleteTaskAsync();
                return result;

            }
            catch (Exception ex)
            {
                return new ResponseModel(404, ex.Message);
            }
        }
        public async Task<ResponseModel> UpdateEmployeeSettingAsync(string id,Employee updateEmployee)
        {
            try
            {
                var employee = await _baseRepository.GetById(id);
                employee.Model.Email = updateEmployee.Email != default ? updateEmployee.Email : employee.Model.Email;
                employee.Model.Phone = updateEmployee.Phone != default ? updateEmployee.Phone : employee.Model.Phone;
                var result = _baseRepository.Update(employee.Model);
                await _unitOfWork.CompleteTaskAsync();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(404, ex.Message);
            }
        }
    }
}
