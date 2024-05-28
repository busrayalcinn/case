using Nowadays.Core.Entities;
using Nowadays.Core.ValueObject;
using Nowadays.DataAccess.Persistence;

namespace Nowadays.DataAccess.Repositories.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NowadaysDbContext _dbContext;
      
        public IBaseRepository<Employee> employeeRepo { get; private set; }
        public IBaseRepository<Issue> issueRepo { get; private set; }
        public IBaseRepository<Project> projectRepo { get; private set; }
        public IBaseRepository<Report> reportRepo { get; private set; }
        public IBaseRepository<ProjectEmployee> pEmployeeRepo { get; private set; }
        public IBaseRepository<Company> compannyRepo { get; private set; }

        public UnitOfWork(NowadaysDbContext dbContext, IBaseRepository<Company> companyRepository, IBaseRepository<Employee> employeeRepository, IBaseRepository<Issue> issueRepository, IBaseRepository<Project> projectRepository, IBaseRepository<Report> reportRepository, IBaseRepository<ProjectEmployee> projectEmployeeRepository)
        {
            _dbContext = dbContext;
            this.compannyRepo = new BaseRepository<Company>(_dbContext);
            this.employeeRepo = new BaseRepository<Employee>(_dbContext);
            this.issueRepo = new BaseRepository<Issue>(_dbContext);
            this.projectRepo = new BaseRepository<Project>(_dbContext);
            this.reportRepo = new BaseRepository<Report>(_dbContext);
            this.pEmployeeRepo = new BaseRepository<ProjectEmployee>(_dbContext);
        }


        public void CompleteTask()
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch 
                {
                    dbContextTransaction.Rollback();
                }
            }
        }
    }
}
