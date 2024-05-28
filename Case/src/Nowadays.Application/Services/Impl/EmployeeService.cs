using Nowadays.Core.Entities;
using Nowadays.Core.ValueObject;
using Nowadays.DataAccess.Repositories;

namespace Nowadays.Application.Services.Impl
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
        public override async Task<Employee> InsertAsync(Employee employee, bool? tCKimlikDogrulaResult)
        {
            try
            {
                if(tCKimlikDogrulaResult == false)
                {
                    throw new Exception("Identity No. is not correct!");
                }
                var result = await _employeeRepository.InsertAsync(employee);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Identity No. is not correct! {ex.Message}");
            }
        }

        public async Task<ProjectEmployee> AssignEmployeeToProject(ProjectEmployee projectEmployee)
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
                _unitOfWork.CompleteTask();
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Employee> UpdateEmployeeSettingAsync(string id,Employee updateEmployee)
        {
            try
            {
                var employee = await _baseRepository.GetById(id);
                employee.Email = updateEmployee.Email != default ? updateEmployee.Email : employee.Email;
                employee.Phone = updateEmployee.Phone != default ? updateEmployee.Phone : employee.Phone;
                var result = _baseRepository.Update(employee);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
