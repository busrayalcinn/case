using AutoMapper;
using Nowadays.Application.Models.Company;
using Nowadays.Application.Models.Employee;
using Nowadays.Application.Models.Issue;
using Nowadays.Application.Models.Project;
using Nowadays.Application.Models.Report;
using Nowadays.Core.Entities;
using Nowadays.Core.ValueObject;

namespace Nowadays.Application.MappingProfiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<ReportCompanyDTO, Company>();
            CreateMap<Company, ReportCompanyDTO>();
            CreateMap<ReportEmployeeDTO, Employee>();
            CreateMap<Employee, ReportEmployeeDTO>();
            CreateMap<ReportProjectDTO, Project>();
            CreateMap<Project, ReportProjectDTO>();


            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();
            CreateMap<Issue, IssueDTO>();
            CreateMap<IssueDTO, Issue>();
            CreateMap<Report, ReportDTO>();
            CreateMap<ReportDTO, Report>();
            CreateMap<ProjectEmployee, ProjectEmployeeDTO>();
            CreateMap<ProjectEmployeeDTO, ProjectEmployee>();

            CreateMap<Project, ProjectSettingDTO>();
            CreateMap<ProjectSettingDTO, Project>();
            CreateMap<Employee, EmployeeSettingDTO>();
            CreateMap<EmployeeSettingDTO, Employee>();
            CreateMap<Issue, IssueSettingDTO>();
            CreateMap<IssueSettingDTO, Issue>();
        }

    }
}
