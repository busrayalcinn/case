using Nowadays.Models;
using Nowadays.Models.ResponseModels;
using Nowadays.Repositories.Abstract;
using Nowadays.Repositories.Abstract.Base;
using Nowadays.Repositories.Concrete.Base;
using Nowadays.Repositories.Concrete;
using Nowadays.Services.Abstract;
using Nowadays.Services.Concrete.Base;
using static Nowadays.Models.Enum.BaseEnum;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Models.DTOs;

namespace Nowadays.Services.Concrete
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
        public async Task<ResponseModel> ChangeIssueSetting(string id, [FromBody] IssueSettingDTO issueSetting)
        {
            try
            {
                var issue = await _repository.GetById(id);
                if (issue is null)
                {
                    throw new Exception("Data is not found");
                }

                string? title = issueSetting.Title != default ? issueSetting.Title : issue.Model.Title;
                string? projectId = issueSetting.ProjectId != default ? issueSetting.ProjectId.ToString() : issue.Model.ProjectId;
               
                if(issue.Model is not null)
                {
                    issue.Model.ProjectId = projectId; 
                    issue.Model!.Title = title;
                }



                ResponseModel result = _repository.Update(issue.Model);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(404, ex.Message);
            }
        }
        public async Task<ResponseModel> UpdateDescription(string id, string Description)
        {
            try
            {
                var issue = await _repository.GetById(id);
                if (issue is null)
                {
                    throw new Exception("Data is not found");
                }
                issue.Model.Description = Description != default ? Description : issue.Model.Description;
                var result = _repository.Update(issue.Model);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(404, ex.Message);
            }
        }
        public async Task<ResponseModel> ChangeStatus(string id,StatusType statusType)
        {
            try
            {
                var issue = await _repository.GetById(id);
                if (issue is null)
                {
                    throw new Exception("Data is not found");
                }
                issue.Model.Status = statusType != default ? statusType : issue.Model.Status;
                var result = _repository.Update(issue.Model);
                 _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(404, ex.Message);
            }
        }
        public async Task<ResponseModel> UpdateIssueAssignEmployee(string id, string emloyeeId)
        {
            try
            {
                var issue = await _repository.GetById(id);
                if (issue is null)
                {
                    throw new Exception("Data is not found");
                }
                if(issue.Model is not null)
                {
                   string employe = emloyeeId != default ? emloyeeId : issue.Model.EmployeeId;

                    issue.Model.EmployeeId = employe;
                }
              
                var result = _repository.Update(issue.Model);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(404, ex.Message);
            }
        }
        public async Task<ResponseModel> UpdateIssueReportingEmployee(string id, string reportingEmployeeId)
        {
            try
            {
                var issue = await _repository.GetById(id);
                if (issue is null)
                {
                    throw new Exception("Data is not found");
                }
                issue.Model.ReportingEmployeeId = reportingEmployeeId != default ? reportingEmployeeId : issue.Model.ReportingEmployeeId;
                var result = _repository.Update(issue.Model);
                _unitOfWork.CompleteTask();
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel(404, ex.Message);
            }
        }
    }
}
