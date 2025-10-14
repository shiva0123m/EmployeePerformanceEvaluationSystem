using Microsoft.AspNetCore.Mvc;
using PerformanceEvaluationSystem.Data;

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
    }
}
