using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Models.ResponseModels;
using Nowadays.Models;
using Nowadays.Services.Abstract;
using Nowadays.Services.Concrete;
using Nowadays.Models.DTOs;
using AutoMapper;

namespace Nowadays.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;
        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ResponseModel<IEnumerable<Project>>> GetAllProject()
        {
            var projectList = await _projectService.GetAll();
            return projectList;
        }
        [HttpGet("{id}")]
        public async Task<ResponseModel<Project>> GetProject(string id)
        {
            var project = await _projectService.GetById(id);
            return project;
        }
        [HttpPost]
        public async Task<ResponseModel> CreateProject([FromBody] ProjectDTO project)
        {
            var projectModel = _mapper.Map<Project>(project);
            var response = await _projectService.InsertAsync(projectModel);
            return response;
        }
        [HttpPut("{id}")]
        public async Task<ResponseModel> UpdateProject(string id,[FromBody] ProjectSettingDTO project)
        {
            var projectModel = _mapper.Map<Project>(project);
            var response = await _projectService.UpdateAsync(id,projectModel);
            return response;
        }
        [HttpDelete("{id}")]
        public async Task<ResponseModel> DeleteProject(string id)
        {
            var response = await _projectService.DeleteAsync(id);
            return response;
        }
    }
}
