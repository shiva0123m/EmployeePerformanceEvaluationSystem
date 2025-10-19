using Microsoft.AspNetCore.Mvc;
using PerformanceEvaluationSystem.Data;
using PerformanceEvaluationSystem.Dto;

namespace PerformanceEvaluationSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // Result: api/employee
    public class EmployeeController : ControllerBase
    {
        private readonly PerformanceEvaluation dbcontext ;
        
        public EmployeeController(PerformanceEvaluation context)
        {
            dbcontext = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var employees = dbcontext.Employees.ToList();
            return Ok(employees);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var employee = dbcontext.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Post([FromBody] EmployeeDtoPayload employeeDto)
        {
            var payload= new Employee
            {
                Name = employeeDto.Name,
                Position = employeeDto.Position,
                TeamId = employeeDto.TeamId
            };
            dbcontext.Employees.Add(payload);
            dbcontext.SaveChanges();
            var response = new ResponseEmployee
            {
                EmployeeId = payload.EmployeeId,
                Name = payload.Name,
                Position = payload.Position,
                TeamId = payload.TeamId
            };
            return CreatedAtAction(nameof(GetById), new { id = response.EmployeeId }, response);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] EmployeeDtoPayload employeeDto)
        {
            var existingEmployee = dbcontext.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.Name = employeeDto.Name;
            existingEmployee.Position = employeeDto.Position;
            existingEmployee.TeamId = employeeDto.TeamId;
            dbcontext.SaveChanges();
           
            return NoContent();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var existingEmployee = dbcontext.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            dbcontext.Employees.Remove(existingEmployee);
            var response = new ResponseEmployee
            {
                EmployeeId = existingEmployee.EmployeeId,
                Name = existingEmployee.Name,
                Position = existingEmployee.Position,
                TeamId = existingEmployee.TeamId
            };
            dbcontext.SaveChanges();
            return Ok(response);
        }
    }
}
