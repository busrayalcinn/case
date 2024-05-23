using Nowadays.Models;
using Nowadays.Models.ResponseModels;
using Nowadays.Repositories.Abstract.Base;

namespace Nowadays.Repositories.Abstract
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        public Task<ResponseModel<List<Project>>> GetProjectByCompanyId(string companyId);
    }
}
