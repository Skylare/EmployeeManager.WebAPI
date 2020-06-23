using AutoMapper;
using EmployeeManager.WebAPI.Dtos;
using EmployeeManager.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.WebAPI.Profiles
{
    public class CountriesProfile: Profile
    {
        public CountriesProfile()
        {
            CreateMap<Country, CountryReadDto>();
            CreateMap<CountryCreateDto, Country>();
            CreateMap<CountryUpdateDto, Country>();
            CreateMap<Country, CountryUpdateDto>();
        }
    }
}
