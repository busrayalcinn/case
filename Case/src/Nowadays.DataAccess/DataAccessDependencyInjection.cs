using Microsoft.Extensions.DependencyInjection;
using Nowadays.Core.Entities;
using Nowadays.Core.ValueObject;
using Nowadays.DataAccess.Repositories.Impl;
using Nowadays.DataAccess.Repositories;
using Nowadays.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Nowadays.DataAccess
{
    public static class DataAccessDependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddRepositories();
            return services;
        }

        private static void AddRepositories(this IServiceCollection services)
        {
           services.AddScoped<IUnitOfWork, UnitOfWork>();

           services.AddScoped<IBaseRepository<Company>, BaseRepository<Company>>();
           services.AddScoped<IBaseRepository<Employee>, BaseRepository<Employee>>();
           services.AddScoped<IBaseRepository<Issue>, BaseRepository<Issue>>();
           services.AddScoped<IBaseRepository<Project>, BaseRepository<Project>>();
           services.AddScoped<IBaseRepository<ProjectEmployee>, BaseRepository<ProjectEmployee>>();
           services.AddScoped<IBaseRepository<Report>, BaseRepository<Report>>();

           services.AddScoped<ICompanyRepository, CompanyRepository>();
           services.AddScoped<IEmployeeRepository, EmployeeRepository>();
           services.AddScoped<IIssueRepository, IssueRepository>();
           services.AddScoped<IProjectRepository, ProjectRepository>();
           services.AddScoped<IReportRepository, ReportRepository>();
           services.AddScoped<IProjectEmployeeRepository, ProjectEmployeeRepository>();

        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NowadaysDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("SQL"))
            );

        }
    }
}
