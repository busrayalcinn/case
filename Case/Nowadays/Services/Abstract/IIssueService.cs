using Microsoft.AspNetCore.Mvc;
using Nowadays.Models;
using Nowadays.Models.DTOs;
using Nowadays.Models.ResponseModels;
using Nowadays.Services.Abstract.Base;
using static Nowadays.Models.Enum.BaseEnum;

namespace Nowadays.Services.Abstract
{
    public interface IIssueService : IBaseService<Issue>
    {
        public Task<ResponseModel> ChangeIssueSetting(string id, [FromBody] IssueSettingDTO ıssueSetting);
        public Task<ResponseModel> UpdateDescription(string id, string Description);
        public Task<ResponseModel> ChangeStatus(string id, StatusType statusType);
        public Task<ResponseModel> UpdateIssueAssignEmployee(string id, string emloyeeId);
        public Task<ResponseModel> UpdateIssueReportingEmployee(string id, string reportingEmployeeId);
    }
}
