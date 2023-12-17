using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _repo;
        public CountryController(ICountryRepository repo)
        {
            _repo = repo;
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateCountry(int Id, DtoCountry model)
        {
            if (await _repo.EditCountry(Id, model))
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetCountries()
        {
            var countries = await _repo.GetCountriesAsync();

            return Ok(countries);
        }
    }
}