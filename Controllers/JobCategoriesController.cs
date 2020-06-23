using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManager.WebAPI.Data;
using EmployeeManager.WebAPI.Dtos;
using EmployeeManager.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.WebAPI.Controllers
{
    [Route("api/jobcategories")]
    [ApiController]
    public class JobCategoriesController : ControllerBase
    {
        private readonly IEmployeeManagerRepository _repository;
        private readonly IMapper _mapper;

        public JobCategoriesController(IEmployeeManagerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<JobCategoryReadDto>> GetAllJobCategories()
        {
            var jobCategories = _repository.GetAllJobCategories();
            return Ok(_mapper.Map<IEnumerable<JobCategoryReadDto>>(jobCategories));
        }

        [HttpGet("{id}", Name = "GetJobCategoryById")]
        public ActionResult<JobCategoryReadDto> GetJobCategoryById(int id)
        {
            var jobCategory = _repository.GetJobCategoryById(id);
            if(jobCategory != null)
            {
                return Ok(_mapper.Map<JobCategoryReadDto>(jobCategory));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<JobCategoryReadDto> CreateJobCategory(JobCategoryCreateDto jobCategoryCreateDto)
        {
            var jobCategoryModel = _mapper.Map<JobCategory>(jobCategoryCreateDto);
            _repository.CreateJobCategory(jobCategoryModel);
            _repository.SaveChanges();

            var jobCategoryReadDto = _mapper.Map<JobCategoryReadDto>(jobCategoryModel);

            return CreatedAtRoute(nameof(GetJobCategoryById), new { Id = jobCategoryReadDto.Id}, jobCategoryReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateJobCategory(int id, JobCategoryUpdateDto jobCategoryUpdateDto)
        {
            var jobCategoryModel = _repository.GetJobCategoryById(id);
            if (jobCategoryModel == null)
            {
                return NotFound();
            }

            _mapper.Map(jobCategoryUpdateDto, jobCategoryModel);

            _repository.UpdateJobCategory(jobCategoryModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteJobCategory(int id)
        {
            var jobCategoryModel = _repository.GetJobCategoryById(id);
            if (jobCategoryModel == null)
            {
                return NotFound();
            }

            _repository.DeleteJobCategory(jobCategoryModel);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
