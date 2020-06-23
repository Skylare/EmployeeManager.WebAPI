using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManager.WebAPI.Data;
using EmployeeManager.WebAPI.Dtos;
using EmployeeManager.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.WebAPI.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeManagerRepository _repository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeManagerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeReadDto>> GetAllEmployees()
        {
            var employees = _repository.GetAllEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employees));
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult<EmployeeReadDto> GetEmployeeById(int id)
        {
            var employee = _repository.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(_mapper.Map<EmployeeReadDto>(employee));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<EmployeeReadDto> CreateEmployee(EmployeeCreateDto employeeCreateDto)
        {
            var employeeModel = _mapper.Map<Employee>(employeeCreateDto);
            
            if(!_repository.CreateEmployee(employeeModel))
            {
                return ValidationProblem();
            }
            
            _repository.SaveChanges();
            
            var employeeReadDto = _mapper.Map<EmployeeReadDto>(employeeModel);

            return CreatedAtRoute(nameof(GetEmployeeById), new { Id = employeeReadDto.Id }, employeeReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, EmployeeUpdateDto employeeUpdateDto)
        {
            var employeeModel = _repository.GetEmployeeById(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            _mapper.Map(employeeUpdateDto, employeeModel);

            if(!_repository.UpdateEmployee(employeeModel))
            {
                return ValidationProblem();
            }
            
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PatchEmployee(int id, JsonPatchDocument<EmployeeUpdateDto> patchDoc)
        {
            var employeeModel = _repository.GetEmployeeById(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            var employeeToPatch = _mapper.Map<EmployeeUpdateDto>(employeeModel);
            patchDoc.ApplyTo(employeeToPatch, ModelState);
            if (!TryValidateModel(employeeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(employeeToPatch, employeeModel);

            _repository.UpdateEmployee(employeeModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employeeModel = _repository.GetEmployeeById(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            _repository.DeleteEmployee(employeeModel);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
