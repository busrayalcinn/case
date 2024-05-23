using Nowadays.Models.ResponseModels;
using Nowadays.Models.ValueObject;
using Nowadays.Repositories.Abstract.Base;

namespace Nowadays.Repositories.Abstract
{
    public interface IProjectEmployeeRepository : IBaseRepository<ProjectEmployee>
    {
        public Task<ResponseModel<List<ProjectEmployee>>> GetByProjectId(string projectId);
    }
}
