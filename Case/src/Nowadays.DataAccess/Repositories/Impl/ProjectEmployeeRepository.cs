using Microsoft.EntityFrameworkCore;
using Nowadays.Core.ValueObject;
using Nowadays.DataAccess.Persistence;

namespace Nowadays.DataAccess.Repositories.Impl
{
    public class ProjectEmployeeRepository : BaseRepository<ProjectEmployee>, IProjectEmployeeRepository
    {
        private readonly NowadaysDbContext _context;
        private DbSet<ProjectEmployee> _projects;
        public ProjectEmployeeRepository(NowadaysDbContext context) : base(context)
        {
            _context = context;
            _projects = _context.Set<ProjectEmployee>();
        }
        public async Task<List<ProjectEmployee>> GetByProjectId(string projectId)
        {
            var project = await _projects.Where(x=>x.ProjectId == projectId).Select(x => new ProjectEmployee
            {
                EmployeeId = x.EmployeeId,
                ProjectId = x.ProjectId,
                CountAssignedIssues = x.CountAssignedIssues,
                CountCompletedIssues = x.CountCompletedIssues,
            }).ToListAsync();
            return project;
        }
    }
}
