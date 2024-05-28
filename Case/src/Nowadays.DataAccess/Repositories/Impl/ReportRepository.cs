using Nowadays.Core.Entities;
using Nowadays.DataAccess.Persistence;

namespace Nowadays.DataAccess.Repositories.Impl
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {
        public ReportRepository(NowadaysDbContext context) : base(context)
        {
        }
    }
}
