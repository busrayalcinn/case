using AutoMapper;
using Nowadays.Application.Models.Report;
using Nowadays.Application.Services;
using Nowadays.Application.Services.Impl;
using Nowadays.Core.Entities;
using Nowadays.DataAccess.Repositories;

namespace Nowadays.Services.Concrete
{
    public class ReportService : BaseService<Report>, IReportService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectEmployeeRepository _projectEmployeeRepository;
        private readonly IMapper _mapper;
        public ReportService(IUnitOfWork unitOfWork, IBaseRepository<Report> baseRepository, ICompanyRepository companyRepository, IMapper mapper, IProjectRepository projectRepository, IProjectEmployeeRepository projectEmployeeRepository, IEmployeeRepository employeeRepository) : base(unitOfWork, baseRepository)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _projectRepository = projectRepository;
            _projectEmployeeRepository = projectEmployeeRepository;
            _employeeRepository = employeeRepository;
        }
        public async Task<ReportDTO> GetReportByCompanyId(string id)
        {
            var companies = await _companyRepository.GetById(id);
            var companyReportModel = _mapper.Map<ReportCompanyDTO>(companies);
            var projects = await _projectRepository.GetProjectByCompanyId(id);

            foreach (var project in projects)
            {
                var projectEmployees = await _projectEmployeeRepository.GetByProjectId(project.Id);
                if(project.ProjectEmployees == null)
                {
                    project.ProjectEmployees = new List<Core.ValueObject.ProjectEmployee>(projectEmployees);
                }
                else
                {
                    project.ProjectEmployees.AddRange(projectEmployees);
                }
                
            }

            var deneme = new List<ReportProjectDTO>();

            if (projects != null)
            {
                foreach(var project in projects)
                {
                    var projectReportModel = _mapper.Map<ReportProjectDTO>(project);
                    foreach(var employee in project.ProjectEmployees)
                    {
                        var projectEmployee = await _employeeRepository.GetById(employee.EmployeeId);
                        var projectEmployeeModel = new ReportEmployeeDTO
                        {
                            FullName = projectEmployee.Name + " " + projectEmployee.SurName,
                            CountAssignedIssues = employee.CountAssignedIssues,
                            CountCompletedIssues = employee.CountCompletedIssues
                        };
                        if (projectReportModel.Employee == null)
                        {
                            projectReportModel.Employee = new List<ReportEmployeeDTO> { projectEmployeeModel };

                        }
                        else
                        {
                            projectReportModel.Employee.Add(projectEmployeeModel);
                        }

                    }
                    deneme.Add(projectReportModel);
                }
                companyReportModel.Project = new List<ReportProjectDTO>(deneme);

            }

            
            
            
            var report = new ReportDTO
            {
                Company = companyReportModel
            };

            return report;
        }

        Task<ReportDTO> IReportService.GetReportByCompanyId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
