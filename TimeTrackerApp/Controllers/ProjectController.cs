using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.DTO.JobType;
using TimeTracker.DTO.Project;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        public readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] ProjectRequestDto projectRequestDto)
        {
            if (projectRequestDto == null)
            {
                return BadRequest(false);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(false);
            }
            await _projectService.Add(projectRequestDto);
            return Ok(projectRequestDto);

        }
    }
}
