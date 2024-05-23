using Nowadays.Models;
using Nowadays.Models.ResponseModels;
using Nowadays.Services.Abstract.Base;

namespace Nowadays.Services.Abstract
{
    public interface ICompanyService : IBaseService<Company>
    {
        public Task<ResponseModel<Company>> GetCompanyById(string id);
        public Task<ResponseModel> UpdateCompanyNameAsync(string id, string name);
    }
}
