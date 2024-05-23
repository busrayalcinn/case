using Microsoft.EntityFrameworkCore;
using Nowadays.EFCoreDbContext;
using Nowadays.Models;
using Nowadays.Repositories.Abstract;
using Nowadays.Repositories.Concrete.Base;

namespace Nowadays.Repositories.Concrete
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(NowadaysDbContext context) : base(context)
        {
        }
    }
}
