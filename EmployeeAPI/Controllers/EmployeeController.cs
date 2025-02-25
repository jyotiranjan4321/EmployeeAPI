using EmployeeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context; 
        public EmployeeController(EmployeeContext context) 
        {
            _context = context; 
        }        
        // GET: api/Employee
         [HttpGet]        
         public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees() 
         {         
            return await _context.Employee.ToListAsync();     
         }

        // GET: api/Employee/5
        [HttpGet("{id}")]        
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {           
            var employee = await _context.Employee.FindAsync(id);     
            if (employee == null)            
            {               
                return NotFound();        
            }          
            return employee;       
        }  
        
        // POST: api/Employee
         [HttpPost]       
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)   
        {       
            _context.Employee.Add(employee);    
            await _context.SaveChangesAsync();  
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeID }, employee);        
        }       
        
        // PUT: api/Employee/5
        [HttpPut("{id}")]    
        public async Task<IActionResult> PutEmployee(int id, Employee employee) 
        {
            if (id != employee.EmployeeID) 
            { 
                return BadRequest(); 
            } 
            
            _context.Entry(employee).State = EntityState.Modified; 
            
            try 
            {
                await _context.SaveChangesAsync(); 
            } 
            
            catch (DbUpdateConcurrencyException) 
            { 
                if (!_context.Employee.Any(e => e.EmployeeID == id)) 
                { 
                    return NotFound(); 
                } 
                
                else 
                { 
                    throw; 
                } 
            } 
            return NoContent(); 
        }
        
        // DELETE: api/Employee/5
         [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteEmployee(int id) 
        { 
            var employee = await _context.Employee.FindAsync(id); 
            if (employee == null) 
            { 
                return NotFound(); 
            } 
            
            _context.Employee.Remove(employee);
            
            await _context.SaveChangesAsync();
            
            return NoContent(); 
        }
    } 
}

