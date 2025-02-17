using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.DTO.Employee;
using TimeTracker.Service.Data;
using TimeTracker.Service.Entities;
using TimeTracker.Service.Services;
using TimeTracker.Service.Services.IServices;

namespace TimeTrackerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService _employeeService;
        
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<EmployeeResponseDto>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAll();
            return Ok(employees);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] EmployeeRequestDto employeeRequestDto)
        {
            if (employeeRequestDto == null)
            {
                return BadRequest(false);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(false);
            }
            await _employeeService.Add(employeeRequestDto);
            return Ok(employeeRequestDto);
            
        }


       
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EmployeeRequestDto employeeRequestDto)
        {
            var updatevalue = await _employeeService.Update(id, employeeRequestDto);
            if (updatevalue == null) // Fix: Update should be updatevalue
            {
                return NotFound();
            }
            return Ok(updatevalue);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponseDto>> GetById(int id)
        {
            var employee = await _employeeService.GetById(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _employeeService.Delete(id);
            if (!result) return NotFound();
            return NoContent();
        }

    }   
}
