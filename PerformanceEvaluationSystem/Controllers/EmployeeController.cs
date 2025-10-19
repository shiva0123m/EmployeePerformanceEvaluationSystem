using Microsoft.AspNetCore.Mvc;
using PerformanceEvaluationSystem.Dto;
using PerformanceEvaluationSystem.Models;

namespace PerformanceEvaluationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Result: api/employee
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _repository.GetAllAsync();
            return Ok(employees);
        }

        /// <summary>
        /// Get employee by id
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        /// <summary>
        /// Create a new employee
        /// </summary>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EmployeeDtoPayload employeeDto)
        {
            if (employeeDto == null)
                return BadRequest("Invalid employee data.");

            var createdEmployee = await _repository.AddAsync(employeeDto);

            return CreatedAtAction(nameof(GetById), new { id = createdEmployee.EmployeeId }, createdEmployee);
        }

        /// <summary>
        /// Update an existing employee
        /// </summary>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] EmployeeDtoPayload employeeDto)
        {
            if (employeeDto == null)
                return BadRequest("Invalid employee data.");

            var updated = await _repository.UpdateAsync(id, employeeDto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Delete an employee
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedEmployee = await _repository.DeleteAsync(id);
            if (deletedEmployee == null)
                return NotFound();

            return Ok(deletedEmployee);
        }
    }
}
