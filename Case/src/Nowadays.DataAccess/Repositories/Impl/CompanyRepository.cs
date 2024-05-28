using Nowadays.Core.Entities;
using Nowadays.DataAccess.Persistence;

namespace Nowadays.DataAccess.Repositories.Impl
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(NowadaysDbContext context) : base(context)
        {
        }
    }
}
