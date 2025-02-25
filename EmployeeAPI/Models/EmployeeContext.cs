using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeAPI.Models
{
    public class EmployeeContext : DbContext 
    { 
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { } 
        public DbSet<Employee> Employee { get; set; } }
}
