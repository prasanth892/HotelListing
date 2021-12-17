using AutoMapper;
using HotelListing.Data.Repositories;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitofWork unitofWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitofWork.Countries.GetAll();
                var results = _mapper.Map<IList<CountryDto>>(countries);

                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCountries)} {ex}");

                return StatusCode(500, "Internal Server Error, Try again later");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitofWork.Countries.Get(q => q.Id == id, new List<string> { "Hotels" });
                var results = _mapper.Map<CountryDto>(country);

                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCountries)} {ex}");

                return StatusCode(500, "Internal Server Error, Try again later");
            }
        }
    }
}
