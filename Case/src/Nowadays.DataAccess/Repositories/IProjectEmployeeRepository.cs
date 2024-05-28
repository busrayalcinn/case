using Nowadays.Core.ValueObject;

namespace Nowadays.DataAccess.Repositories
{
    public interface IProjectEmployeeRepository : IBaseRepository<ProjectEmployee>
    {
        public Task<List<ProjectEmployee>> GetByProjectId(string projectId);
    }
}
