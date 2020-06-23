using AutoMapper;
using EmployeeManager.WebAPI.Dtos;
using EmployeeManager.WebAPI.Models;

namespace EmployeeManager.WebAPI.Profiles
{
    public class JobCategoriesProfile: Profile
    {
        public JobCategoriesProfile()
        {
            CreateMap<JobCategory, JobCategoryReadDto>();
            CreateMap<JobCategoryCreateDto, JobCategory>();
            CreateMap<JobCategoryUpdateDto, JobCategory>();
            CreateMap<JobCategory, JobCategoryUpdateDto>();
        }
    }
}
