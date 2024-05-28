using Nowadays.Models;
using Nowadays.Models.ResponseModels;
using Nowadays.Repositories.Abstract;
using Nowadays.Repositories.Concrete.Base;
using Nowadays.Services.Abstract;
using Nowadays.Services.Concrete.Base;

namespace Nowadays.Services.Concrete
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
        public override async Task<ResponseModel> InsertAsync(Project project)
        {
            try
            {
                var company = _companyRepository.GetById(project.CompanyId);
                if (company is null)
                {
                    throw new Exception("Company Id is not valid.");
                }
                var result = await _repository.InsertAsync(project);
                await _unitOfWork.CompleteTaskAsync();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(400, ex.Message);
            }
        }
        public override async Task<ResponseModel> UpdateAsync(string id, Project updatedProject)
        {
            try
            {
                var project = await _repository.GetById(id);
                if (project.Model is null)
                {
                    throw new Exception("Data is not found");
                }
                project.Model.ProjectLeader = updatedProject.ProjectLeader != default ? updatedProject.ProjectLeader : project.Model.ProjectLeader;
                project.Model.ProjectKey = updatedProject.ProjectKey != default ? updatedProject.ProjectKey : project.Model.ProjectKey;
                project.Model.Name = updatedProject.Name != default ? updatedProject.Name : project.Model.Name;
                var result = _repository.Update(project.Model);
                await _unitOfWork.CompleteTaskAsync();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(404, ex.Message);
            }
        }
    }
}
