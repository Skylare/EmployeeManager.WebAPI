using EmployeeManager.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.WebAPI.Dtos
{
    public class EmployeeReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public JobCategory JobCategory { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Country Country { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime ExitedDate { get; set; }
    }
}
