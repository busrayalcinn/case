using Microsoft.EntityFrameworkCore;
using Nowadays.EFCoreDbContext;
using Nowadays.Models;
using Nowadays.Models.ValueObject;
using Nowadays.Repositories.Abstract;
using Nowadays.Repositories.Concrete.Base;

namespace Nowadays.Repositories.Concrete
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(NowadaysDbContext context) : base(context)
        {
        }
    }
}
