using Microsoft.EntityFrameworkCore;
using Nowadays.EFCoreDbContext;
using Nowadays.Models;
using Nowadays.Models.ResponseModels;
using Nowadays.Repositories.Abstract;
using Nowadays.Repositories.Concrete.Base;

namespace Nowadays.Repositories.Concrete
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
        public async Task<ResponseModel<List<Project>>> GetProjectByCompanyId(string companyId)
        {
            var project = await _projects.Where(x => x.CompanyId == companyId).ToListAsync();
            return new ResponseModel<List<Project>>(project);
        }
    }   
}
