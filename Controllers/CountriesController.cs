using System;
using System.Collections.Generic;
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
    [Route("api/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IEmployeeManagerRepository _repository;
        private readonly IMapper _mapper;

        public CountriesController(IEmployeeManagerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CountryReadDto>> GetAllCountries()
        {
            var countries = _repository.GetAllCountries();
            return Ok(_mapper.Map<IEnumerable<CountryReadDto>>(countries));
        }

        [HttpGet("{id}", Name = "GetCountryById")]
        public ActionResult<CountryReadDto> GetCountryById(int id)
        {
            var country = _repository.GetCountryById(id);
            if (country != null)
            {
                return Ok(_mapper.Map<CountryReadDto>(country));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CountryReadDto> CreateCountry(CountryCreateDto countryCreateDto)
        {
            var countryModel = _mapper.Map<Country>(countryCreateDto);
            _repository.CreateCountry(countryModel);
            _repository.SaveChanges();

            var countryReadDto = _mapper.Map<CountryReadDto>(countryModel);

            return CreatedAtRoute(nameof(GetCountryById), new { Id = countryReadDto.Id }, countryReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCountry(int id, CountryUpdateDto countryUpdateDto)
        {
            var countryModel = _repository.GetCountryById(id);
            if (countryModel == null)
            {
                return NotFound();
            }

            _mapper.Map(countryUpdateDto, countryModel);

            _repository.UpdateCountry(countryModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCountry(int id)
        {
            var countryModel = _repository.GetCountryById(id);
            if (countryModel == null)
            {
                return NotFound();
            }

            _repository.DeleteCountry(countryModel);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
