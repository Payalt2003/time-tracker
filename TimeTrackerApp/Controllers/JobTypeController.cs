using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using TimeTracker.DTO.Employee;
using TimeTracker.DTO.JobType;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Services;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTypeController : ControllerBase
    {


        public readonly IJobTypeService _jobtypeService;

        public JobTypeController(IJobTypeService jobTypeService)
        {
            _jobtypeService = jobTypeService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<JobTypeResponseDto>>> GetAllJobTypes()
        {
            var jobtypes = await _jobtypeService.GetAll();
            return Ok(jobtypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobTypeResponseDto>> GetById(int id)
        {
            var jobtype = await _jobtypeService.GetById(id);
            if (jobtype == null) return NotFound();
            return Ok(jobtype);
        }

       


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] JobTypeRequestDto jobTypeRequestDto)
        {
            if (jobTypeRequestDto == null)
            {
                return BadRequest(false);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(false);
            }
            await _jobtypeService.Add(jobTypeRequestDto);
            return Ok(jobTypeRequestDto);

        }
        [HttpPut("Update /{id}")]



        public async Task<IActionResult> Update(int id, [FromBody] JobTypeRequestDto jobTypeRequestDto)
        {
            if (jobTypeRequestDto == null) return BadRequest();

            var updateValue = await _jobtypeService.Update(id, jobTypeRequestDto);
            if (updateValue == null) return NotFound();

            return Ok(updateValue);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _jobtypeService.Delete(id);

            if (!result)
                return NotFound();

            return NoContent();
        }

    }

}











    




           


            
    









    



