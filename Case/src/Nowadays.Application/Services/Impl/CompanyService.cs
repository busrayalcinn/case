using Nowadays.Application.Services.Impl;
using Nowadays.Core.Entities;
using Nowadays.DataAccess.Repositories;

namespace  Nowadays.Application.Services.Impl
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
        public async Task<Company> GetCompanyById(string id)
        {
            var company = await _companyRepository.GetById(id);
            var companyProjects = await _projectRepository.GetProjectByCompanyId(id);
            if(companyProjects != null)
            {
                company.Project = new List<Project>(companyProjects);
            }
            return company;          
        }
        public async Task<Company> UpdateCompanyNameAsync(string id, string name)
        {
            try
            {
                var company = await _companyRepository.GetById(id);
                company.Name = name != default ? name : company.Name;
                var result = _companyRepository.Update(company);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch(Exception ex)
            {
               throw new Exception($"{id}: {name}", ex);
            }

        }
    }
}
