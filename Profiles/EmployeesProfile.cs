using AutoMapper;
using EmployeeManager.WebAPI.Dtos;
using EmployeeManager.WebAPI.Models;

namespace EmployeeManager.WebAPI.Profiles
{
    public class EmployeesProfile: Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee, EmployeeReadDto>();

            CreateMap<EmployeeCreateDto, Employee>();
              

            CreateMap<EmployeeUpdateDto, Employee>();
            CreateMap<Employee, EmployeeUpdateDto>();
        }
    }
}
