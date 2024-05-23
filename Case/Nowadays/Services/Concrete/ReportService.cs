using AutoMapper;
using Nowadays.Models;
using Nowadays.Models.DTOs;
using Nowadays.Models.ResponseModels;
using Nowadays.Repositories.Abstract;
using Nowadays.Repositories.Abstract.Base;
using Nowadays.Repositories.Concrete;
using Nowadays.Services.Abstract;
using Nowadays.Services.Concrete.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        public async Task<ResponseModel<ReportDTO>> GetReportByCompanyId(string id)
        {
            var companies = await _companyRepository.GetById(id);
            var companyReportModel = _mapper.Map<ReportCompanyDTO>(companies.Model);
            var projects = await _projectRepository.GetProjectByCompanyId(id);

            foreach (var project in projects.Model)
            {
                var projectEmployees = await _projectEmployeeRepository.GetByProjectId(project.Id);
                if(project.ProjectEmployees == null)
                {
                    project.ProjectEmployees = new List<Models.ValueObject.ProjectEmployee>(projectEmployees.Model);
                }
                else
                {
                    project.ProjectEmployees.AddRange(projectEmployees.Model);
                }
                
            }

            var deneme = new List<ReportProjectDTO>();

            if (projects.Model != null)
            {
                foreach(var project in projects.Model)
                {
                    var projectReportModel = _mapper.Map<ReportProjectDTO>(project);
                    foreach(var employee in project.ProjectEmployees)
                    {
                        var projectEmployee = await _employeeRepository.GetById(employee.EmployeeId);
                        var projectEmployeeModel = new ReportEmployeeDTO
                        {
                            FullName = projectEmployee.Model.Name + " " + projectEmployee.Model.SurName,
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

            return new ResponseModel<ReportDTO>(200,report);
        }
    }
}
