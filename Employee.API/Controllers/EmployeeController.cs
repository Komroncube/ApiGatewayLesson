using Employee.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeProjectContext dbContext;

        public EmployeeController(EmployeeProjectContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAll()
        {
            var employees = await dbContext.Employees.ToListAsync();
            return Ok(employees);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetEmployeeById(int id)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(employee);
        }
        [HttpPatch]
        public async ValueTask<IActionResult> UpdateEmployeeName(int id, string name)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            employee.Name = name;
            await dbContext.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
