using Nowadays.Models;
using Nowadays.Models.ResponseModels;
using Nowadays.Models.ValueObject;
using Nowadays.Services.Abstract.Base;

namespace Nowadays.Services.Abstract
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        public Task<ResponseModel> AssignEmployeeToProject(ProjectEmployee employee);
        public Task<ResponseModel> UpdateEmployeeSettingAsync(string id, Employee updateEmployee);
    }
}
