using Nowadays.Models;
using Nowadays.Models.ResponseModels;
using Nowadays.Repositories.Abstract;
using Nowadays.Repositories.Concrete;
using Nowadays.Services.Abstract;
using Nowadays.Services.Concrete.Base;

namespace Nowadays.Services.Concrete
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        private readonly IBaseRepository<Company> _companyRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CompanyService(IUnitOfWork unitOfWork, IBaseRepository<Company> companyRepository, IProjectRepository projectRepository) : base(unitOfWork, companyRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyRepository;
            _projectRepository = projectRepository;
        }
        public async Task<ResponseModel<Company>> GetCompanyById(string id)
        {
            var company = await _companyRepository.GetById(id);
            var companyProjects = await _projectRepository.GetProjectByCompanyId(id);
            if(companyProjects.Model != null)
            {
                company.Model.Project = new List<Project>(companyProjects.Model);
            }
            return company;          
        }
        public async Task<ResponseModel> UpdateCompanyNameAsync(string id, string name)
        {
            try
            {
                var company = await _companyRepository.GetById(id);
                company.Model.Name = name != default ? name : company.Model.Name;
                var result = _companyRepository.Update(company.Model);
                await _unitOfWork.CompleteTaskAsync();
                return result;
            }
            catch(Exception ex)
            {
                return new ResponseModel(404, ex.Message);
            }

        }
    }
}
