using EmployeeCRUDApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
       
            private readonly CrudDemoDbContext _context;

            public EmployeeController(CrudDemoDbContext context)
            {
                _context = context;
            }

         
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var employees = await _context.Employees.ToListAsync();
                return Ok(employees);
            }

            // GET: api/employee/1
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var emp = await _context.Employees.FindAsync(id);
                if (emp == null) return NotFound();
                return Ok(emp);
            }

            [HttpPost]
            public async Task<IActionResult> Create(Employee employee)
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return Ok(employee);
            }

     
            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, Employee employee)
            {
                if (id != employee.Id) return BadRequest();

                _context.Entry(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(employee);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var emp = await _context.Employees.FindAsync(id);
                if (emp == null) return NotFound();

                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();

                return Ok("Deleted Successfully");
            }
    }
}

