using Microsoft.EntityFrameworkCore;
using Nowadays.EFCoreDbContext;
using Nowadays.Models;
using Nowadays.Models.ResponseModels;
using Nowadays.Repositories.Abstract;
using Nowadays.Repositories.Concrete.Base;
using static Nowadays.Models.Enum.BaseEnum;

namespace Nowadays.Repositories.Concrete
{
    public class IssueRepository : BaseRepository<Issue>, IIssueRepository
    {
        public IssueRepository(NowadaysDbContext context) : base(context)
        {
        }
    }
}
