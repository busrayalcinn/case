using Microsoft.EntityFrameworkCore;
using Nowadays.EFCoreDbContext;
using Nowadays.Models;
using Nowadays.Repositories.Abstract;
using Nowadays.Repositories.Concrete.Base;

namespace Nowadays.Repositories.Concrete
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        public ReportRepository(NowadaysDbContext context) : base(context)
        {
        }
    }
}
