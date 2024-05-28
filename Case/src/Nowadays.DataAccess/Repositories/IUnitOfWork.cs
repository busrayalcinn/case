using Nowadays.Core.Entities;

namespace Nowadays.DataAccess.Repositories
{
    public interface IUnitOfWork 
    {
        void CompleteTask();
        public IBaseRepository<Company> compannyRepo { get; }
        public IBaseRepository<Employee> employeeRepo { get; }
        public IBaseRepository<Issue> issueRepo { get; }
        public IBaseRepository<Project> projectRepo { get; }
        public IBaseRepository<Report> reportRepo { get; }


    }
}
