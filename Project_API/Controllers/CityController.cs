using _Services.Contracts;
using _Services.Models.City;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public IActionResult GetAllCities()
        {
            var cities = _cityService.GetCities();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCityById(int id)
        {
            var city = _cityService.GetCityById(id);
            if (city == null)
                return NotFound();

            return Ok(city);
        }

        [HttpPost]
        public IActionResult AddCity(City_Add city)
        {
            _cityService.CreateCity(city);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCity(int id, City_Update city)
        {
            _cityService.UpdateCity(id, city);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            _cityService.DeleteCity(id);
            return Ok();
        }
    }
}
