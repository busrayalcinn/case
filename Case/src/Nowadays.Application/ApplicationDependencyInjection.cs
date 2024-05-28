using Microsoft.Extensions.DependencyInjection;
using Nowadays.Application.Services.Impl;
using Nowadays.Application.Services;
using Nowadays.Services.Concrete;
using AutoMapper;
using System.Reflection;
using Nowadays.Application.MappingProfiles;

namespace Nowadays.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();
            services.RegisterAutoMapper();
            return services;
        }

        private static void AddServices(this IServiceCollection services)
        {
           services.AddScoped<ICompanyService, CompanyService>();
           services.AddScoped<IEmployeeService, EmployeeService>();
           services.AddScoped<IIssueService, IssueService>();
           services.AddScoped<IProjectService, ProjectService>();
           services.AddScoped<IReportService, ReportService>();

        }

        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });
            IMapper mapper = mapperConfig.CreateMapper();


            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSingleton(mapper);

        }
    }
}
