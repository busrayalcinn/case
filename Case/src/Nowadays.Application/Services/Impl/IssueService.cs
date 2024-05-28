using Nowadays.Application.Models.Issue;
using Nowadays.Core.Entities;
using Nowadays.DataAccess.Repositories;
using static Nowadays.Core.Enum.BaseEnum;

namespace Nowadays.Application.Services.Impl
{
    public class IssueService : BaseService<Issue>, IIssueService
    {
        private readonly IIssueRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public IssueService(IUnitOfWork unitOfWork, IBaseRepository<Issue> baseRepository, IIssueRepository repository) : base(unitOfWork, baseRepository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Issue> ChangeIssueSetting(string id, IssueSettingDTO issueSetting)
        {
            try
            {
                var issue = await _repository.GetById(id);
                if (issue is null)
                {
                    throw new Exception("Data is not found");
                }

                string? title = issueSetting.Title != default ? issueSetting.Title : issue.Title;
                string? projectId = issueSetting.ProjectId != default ? issueSetting.ProjectId.ToString() : issue.ProjectId;
               
                if(issue is not null)
                {
                    issue.ProjectId = projectId; 
                    issue!.Title = title;
                }



                Issue result = _repository.Update(issue);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Issue> UpdateDescription(string id, string Description)
        {
            try
            {
                var issue = await _repository.GetById(id);
                if (issue is null)
                {
                    throw new Exception("Data is not found");
                }
                issue.Description = Description != default ? Description : issue.Description;
                var result = _repository.Update(issue);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Issue> ChangeStatus(string id, StatusType statusType)
        {
            try
            {
                var issue = await _repository.GetById(id);
                if (issue is null)
                {
                    throw new Exception("Data is not found");
                }
                issue.Status = statusType != default ? statusType : issue.Status;
                var result = _repository.Update(issue);
                 _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Issue> UpdateIssueAssignEmployee(string id, string emloyeeId)
        {
            try
            {
                var issue = await _repository.GetById(id);
                if (issue is null)
                {
                    throw new Exception("Data is not found");
                }
                if(issue is not null)
                {
                   string employe = emloyeeId != default ? emloyeeId : issue.EmployeeId;

                    issue.EmployeeId = employe;
                }
              
                var result = _repository.Update(issue);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Issue> UpdateIssueReportingEmployee(string id, string reportingEmployeeId)
        {
            try
            {
                var issue = await _repository.GetById(id);
                if (issue is null)
                {
                    throw new Exception("Data is not found");
                }
                issue.ReportingEmployeeId = reportingEmployeeId != default ? reportingEmployeeId : issue.ReportingEmployeeId;
                var result = _repository.Update(issue);
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
