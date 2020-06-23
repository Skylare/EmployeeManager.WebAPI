using EmployeeManager.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.WebAPI.Data
{
    public class EmployeeManagerContext: DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public EmployeeManagerContext(DbContextOptions<EmployeeManagerContext> options) : base(options)
        {

        }
    }
}
