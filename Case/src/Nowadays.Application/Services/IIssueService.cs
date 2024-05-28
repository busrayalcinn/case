using Nowadays.Application.Models.Issue;
using Nowadays.Core.Entities;
using static Nowadays.Core.Enum.BaseEnum;

namespace Nowadays.Application.Services
{
    public interface IIssueService : IBaseService<Issue>
    {
        public Task<Issue> ChangeIssueSetting(string id, IssueSettingDTO ıssueSetting);
        public Task<Issue> UpdateDescription(string id, string Description);
        public Task<Issue> ChangeStatus(string id, StatusType statusType);
        public Task<Issue> UpdateIssueAssignEmployee(string id, string emloyeeId);
        public Task<Issue> UpdateIssueReportingEmployee(string id, string reportingEmployeeId);
    }
}
