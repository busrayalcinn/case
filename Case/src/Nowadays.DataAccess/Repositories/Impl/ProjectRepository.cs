using Microsoft.EntityFrameworkCore;
using Nowadays.Core.Entities;
using Nowadays.DataAccess.Persistence;

namespace Nowadays.DataAccess.Repositories.Impl
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly NowadaysDbContext _context;
        private readonly DbSet<Project> _projects;
        public ProjectRepository(NowadaysDbContext context) : base(context)
        {
            _context = context;
            _projects = _context.Set<Project>();
        }
        public async Task<List<Project>> GetProjectByCompanyId(string companyId)
        {
            var project = await _projects.Where(x => x.CompanyId == companyId).ToListAsync();
            return project;
        }
    }   
}
