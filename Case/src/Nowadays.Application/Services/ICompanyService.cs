using Nowadays.Core.Entities;

namespace Nowadays.Application.Services
{
    public interface ICompanyService : IBaseService<Company>
    {
        public Task<Company> GetCompanyById(string id);
        public Task<Company> UpdateCompanyNameAsync(string id, string name);
    }
}
