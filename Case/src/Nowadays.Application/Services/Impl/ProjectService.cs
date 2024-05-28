using Nowadays.Core.Entities;
using Nowadays.DataAccess.Repositories;

namespace Nowadays.Application.Services.Impl
{
    public class ProjectService : BaseService<Project>, IProjectService
    {
        private readonly IBaseRepository<Project> _repository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IUnitOfWork unitOfWork, IBaseRepository<Project> baseRepository, ICompanyRepository companyRepository) : base(unitOfWork, baseRepository)
        {
            _repository = baseRepository;
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
        }
        public override async Task<Project> InsertAsync(Project project, bool? tckimliknodogrulamaResult = null )
        {
            try
            {
                var company = _companyRepository.GetById(project.CompanyId);
                if (company is null)
                {
                    throw new Exception("Company Id is not valid.");
                }
                var result = await _repository.InsertAsync(project);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public override async Task<Project> UpdateAsync(string id, Project updatedProject)
        {
            try
            {
                var project = await _repository.GetById(id);
                if (project is null)
                {
                    throw new Exception("Data is not found");
                }
                project.ProjectLeader = updatedProject.ProjectLeader != default ? updatedProject.ProjectLeader : project.ProjectLeader;
                project.ProjectKey = updatedProject.ProjectKey != default ? updatedProject.ProjectKey : project.ProjectKey;
                project.Name = updatedProject.Name != default ? updatedProject.Name : project.Name;
                var result = _repository.Update(project);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
