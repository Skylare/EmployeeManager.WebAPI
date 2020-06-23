using EmployeeManager.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.WebAPI.Data
{
    public interface IEmployeeManagerRepository
    {
        bool SaveChanges();

        IEnumerable<Country> GetAllCountries();
        Country GetCountryById(int id);
        void CreateCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(Country country);

        IEnumerable<JobCategory> GetAllJobCategories();
        JobCategory GetJobCategoryById(int id);
        void CreateJobCategory(JobCategory jobCategory);
        void UpdateJobCategory(JobCategory jobCategory);
        void DeleteJobCategory(JobCategory jobCategory);

        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
