using EmployeeManager.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManager.WebAPI.Data
{
    public class SqliteEmployeeManagerRepository : IEmployeeManagerRepository
    {
        private readonly EmployeeManagerContext _context;

        public SqliteEmployeeManagerRepository(EmployeeManagerContext context)
        {
            _context = context;
        }

        public bool CreateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            // check that selected country and jobcategory exist
            if(GetCountryById((int)employee.CountryId) == null) { return false; }
            if(GetJobCategoryById((int)employee.JobCategoryId) == null) { return false; }

            _context.Employees.Add(employee);
            return true;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = _context.Employees
                .Include(e => e.Country)
                .Include(e => e.JobCategory)
                .ToList();
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _context.Employees
                .Include(e => e.Country)
                .Include(e => e.JobCategory)
                .FirstOrDefault(e => e.Id == id);
            return employee;
        }

        public bool UpdateEmployee(Employee employee)
        {
            if (GetCountryById((int)employee.CountryId) == null) { return false; }
            if (GetJobCategoryById((int)employee.JobCategoryId) == null) { return false; }

            return true;
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _context.Employees.Remove(employee);
        }


        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(int id)
        {
            return _context.Countries.FirstOrDefault(jc => jc.Id == id);
        }

        public void CreateCountry(Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            _context.Countries.Add(country);
        }

        public void UpdateCountry(Country country)
        {
            // do nothing, but keep the function anyway
        }

        public void DeleteCountry(Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            _context.Countries.Remove(country);
        }


        public IEnumerable<JobCategory> GetAllJobCategories()
        {
            return _context.JobCategories.ToList();
        }

        public JobCategory GetJobCategoryById(int id)
        {
            return _context.JobCategories.FirstOrDefault(jc => jc.Id == id);
        }

        public void CreateJobCategory(JobCategory jobCategory)
        {
            if (jobCategory == null)
            {
                throw new ArgumentNullException(nameof(jobCategory));
            }

            _context.JobCategories.Add(jobCategory);
        }

        public void UpdateJobCategory(JobCategory jobCategory)
        {
            // do nothing, but keep the function anyway
        }

        public void DeleteJobCategory(JobCategory jobCategory)
        {
            if (jobCategory == null)
            {
                throw new ArgumentNullException(nameof(jobCategory));
            }

            _context.JobCategories.Remove(jobCategory);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
