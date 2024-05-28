using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Application.Models.Issue;
using Nowadays.Application.Services;
using Nowadays.Core.Entities;
using Nowadays.Core.Enum;
using static Nowadays.Core.Enum.BaseEnum;

namespace Nowadays.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;
        private readonly IMapper _mapper;

        public IssueController(IIssueService issueService, IMapper mapper)
        {
            _issueService = issueService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Issue>> GetAllIssue()
        {
            var issueList = await _issueService.GetAll();
            return issueList;
        }
        [HttpGet("{id}")]
        public async Task<Issue> GetIssue(string id)
        {
            var issue = await _issueService.GetById(id);
            return issue;
        }
        [HttpPost]
        public async Task<Issue> CreateIssue([FromBody] IssueDTO issue)
        {
            var issueModel = _mapper.Map<Issue>(issue);

            issueModel.Status = BaseEnum.StatusType.SELECTED_FOR_DEVELOPMENT;
            var response = await _issueService.InsertAsync(issueModel);
            return response;
        }
        [HttpPut("{id}")]
        public async Task<Issue> ChangeIssueSetting(string id, [FromBody] IssueSettingDTO ıssueSetting)
        {
            var response = await _issueService.ChangeIssueSetting(id, ıssueSetting);
            return response;
        }
        [HttpPatch("{id}/changeStatus")]
        public async Task<Issue> ChangeStatus(string id,[FromBody]StatusType statusType)
        {
            var response = await _issueService.ChangeStatus(id,statusType);
            return response;
        }
        [HttpPatch("{id}/updateDescription")]
        public async Task<Issue> UpdateDescription(string id,[FromBody] string Description)
        {
            var response = await _issueService.UpdateDescription(id, Description);
            return response;
        }
        [HttpPatch("assignEmployee/{id}/{employeeId}")]
        public async Task<Issue> UpdateIssueAssignEmployee(string id, string employeeId)
        {
            var response = await _issueService.UpdateIssueAssignEmployee(id, employeeId);
            return response;
        }
        [HttpPatch("{id}/{reportingEmployeeId}")]
        public async Task<Issue> UpdateIssueReportingEmployee(string id, string reportingEmployeeId)
        {
            var response = await _issueService.UpdateIssueReportingEmployee(id, reportingEmployeeId);
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<Issue> DeleteIssue(string id)
        {
            var response = await _issueService.DeleteAsync(id);
            return response;
        }
    }
}
