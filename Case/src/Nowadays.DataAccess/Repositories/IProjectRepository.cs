using Nowadays.Core.Entities;

namespace Nowadays.DataAccess.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        public Task<List<Project>> GetProjectByCompanyId(string companyId);
    }
}
