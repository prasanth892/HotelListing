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
    public class HotelController : ControllerBase
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitofWork unitofWork, ILogger<HotelController> logger, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var hotels = await _unitofWork.Hotels.GetAll();
                var results = _mapper.Map<IList<HotelDto>>(hotels);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAll)} {ex}");

                return StatusCode(500, "Internal Server Error, Try again later");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var hotel = await _unitofWork.Hotels.Get(q => q.Id == id, new List<string> { "Country" });
                var results = _mapper.Map<HotelDto>(hotel);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAll)} {ex}");

                return StatusCode(500, "Internal Server Error, Try again later");
            }
        }
    }
}
