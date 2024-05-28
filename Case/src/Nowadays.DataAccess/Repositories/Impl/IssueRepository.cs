using Nowadays.Core.Entities;
using Nowadays.DataAccess.Persistence;

namespace Nowadays.DataAccess.Repositories.Impl
{
    public class IssueRepository : BaseRepository<Issue>, IIssueRepository
    {
        public IssueRepository(NowadaysDbContext context) : base(context)
        {
        }
    }
}
