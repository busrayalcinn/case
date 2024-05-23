using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Models.ResponseModels;
using Nowadays.Models.ValueObject;
using Nowadays.Models;
using Nowadays.Services.Abstract;
using Nowadays.Services.Concrete;
using Nowadays.Models.DTOs;
using AutoMapper;
using static Nowadays.Models.Enum.BaseEnum;

namespace Nowadays.Controllers
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
        public async Task<ResponseModel<IEnumerable<Issue>>> GetAllIssue()
        {
            var issueList = await _issueService.GetAll();
            return issueList;
        }
        [HttpGet("{id}")]
        public async Task<ResponseModel<Issue>> GetIssue(string id)
        {
            var issue = await _issueService.GetById(id);
            return issue;
        }
        [HttpPost]
        public async Task<ResponseModel> CreateIssue([FromBody] IssueDTO issue)
        {
            var issueModel = _mapper.Map<Issue>(issue);
            issueModel.Status = Models.Enum.BaseEnum.StatusType.SELECTED_FOR_DEVELOPMENT;
            var response = await _issueService.InsertAsync(issueModel);
            return response;
        }
        [HttpPut("{id}")]
        public async Task<ResponseModel> ChangeIssueSetting(string id, [FromBody] IssueSettingDTO ıssueSetting)
        {
            var response = await _issueService.ChangeIssueSetting(id, ıssueSetting);
            return response;
        }
        [HttpPatch("{id}/changeStatus")]
        public async Task<ResponseModel> ChangeStatus(string id,[FromBody]StatusType statusType)
        {
            var response = await _issueService.ChangeStatus(id,statusType);
            return response;
        }
        [HttpPatch("{id}/updateDescription")]
        public async Task<ResponseModel> UpdateDescription(string id,[FromBody] string Description)
        {
            var response = await _issueService.UpdateDescription(id, Description);
            return response;
        }
        [HttpPatch("assignEmployee/{id}/{employeeId}")]
        public async Task<ResponseModel> UpdateIssueAssignEmployee(string id, string employeeId)
        {
            var response = await _issueService.UpdateIssueAssignEmployee(id, employeeId);
            return response;
        }
        [HttpPatch("{id}/{reportingEmployeeId}")]
        public async Task<ResponseModel> UpdateIssueReportingEmployee(string id, string reportingEmployeeId)
        {
            var response = await _issueService.UpdateIssueReportingEmployee(id, reportingEmployeeId);
            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ResponseModel> DeleteIssue(string id)
        {
            var response = await _issueService.DeleteAsync(id);
            return response;
        }
    }
}
