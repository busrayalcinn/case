using Nowadays.Core.Entities;
using Nowadays.Core.ValueObject;

namespace Nowadays.Application.Services
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        public Task<ProjectEmployee> AssignEmployeeToProject(ProjectEmployee employee);
        public Task<Employee> UpdateEmployeeSettingAsync(string id, Employee updateEmployee);
    }
}
