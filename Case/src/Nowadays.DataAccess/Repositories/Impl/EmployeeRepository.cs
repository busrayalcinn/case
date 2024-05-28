using Nowadays.Core.Entities;
using Nowadays.DataAccess.Persistence;

namespace Nowadays.DataAccess.Repositories.Impl
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(NowadaysDbContext context) : base(context)
        {
        }
    }
}
