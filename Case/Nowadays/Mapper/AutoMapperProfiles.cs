using AutoMapper;
using Nowadays.Models;
using Nowadays.Models.DTOs;
using Nowadays.Models.ValueObject;

namespace Nowadays.Mapper
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
