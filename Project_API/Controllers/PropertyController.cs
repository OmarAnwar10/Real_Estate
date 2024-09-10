using Microsoft.AspNetCore.Mvc;
using Application.ServiceContracts;
using API_Project.DataAccess.DTOs;
using System.Collections.Generic;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService_Dto _propertyService;

        public PropertyController(IPropertyService_Dto propertyService)
        {
            _propertyService = propertyService;
        }

        // Get all properties
        [HttpGet]
        public IActionResult GetAllProperties()
        {
            var properties = _propertyService.GetAllProperties();
            return Ok(properties);
        }

        // Get property by ID
        [HttpGet("{id}")]
        public IActionResult GetPropertyById(int id)
        {
            var property = _propertyService.GetPropertyById(id);
            if (property == null)
                return NotFound("Property not found.");
            
            return Ok(property);
        }

        // Create a new property
        [HttpPost]
        public IActionResult CreateProperty([FromBody] PropertyDto propertyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _propertyService.CreateProperty(propertyDto);
            return Ok("Property created successfully.");
        }

        // Update an existing property
        [HttpPut("{id}")]
        public IActionResult UpdateProperty(int id, [FromBody] PropertyDto propertyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _propertyService.UpdateProperty(propertyDto);
            return Ok("Property updated successfully.");
        }

        // Delete a property by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteProperty(int id)
        {
            _propertyService.DeleteProperty(id);
            return Ok("Property deleted successfully.");
        }

        // Get properties by price range
        [HttpGet("price")]
        public IActionResult GetPropertiesByPrice([FromQuery] decimal minPrice, [FromQuery] decimal maxPrice)
        {
            var properties = _propertyService.GetPropertiesByPrice(minPrice, maxPrice);
            return Ok(properties);
        }

        // Search for properties by term
        [HttpGet("search")]
        public IActionResult SearchProperties([FromQuery] string searchTerm)
        {
            var properties = _propertyService.SearchProperties(searchTerm);
            return Ok(properties);
        }

        // Filter properties
        [HttpGet("filter")]
        public IActionResult FilterProperties([FromQuery] string location, [FromQuery] string propertyType,
                                              [FromQuery] int? minBedrooms, [FromQuery] int? maxBedrooms,
                                              [FromQuery] int? minBathrooms, [FromQuery] int? maxBathrooms)
        {
            var properties = _propertyService.FilterProperties(location, propertyType, minBedrooms, maxBedrooms, minBathrooms, maxBathrooms);
            return Ok(properties);
        }

        // Get properties ordered by price
        [HttpGet("order/price")]
        public IActionResult GetPropertiesOrderedByPrice([FromQuery] bool ascending = true)
        {
            var properties = _propertyService.GetPropertiesOrderedByPrice(ascending);
            return Ok(properties);
        }

        // Get properties ordered by date added
        [HttpGet("order/date")]
        public IActionResult GetPropertiesOrderedByDateAdded([FromQuery] bool ascending = true)
        {
            var properties = _propertyService.GetPropertiesOrderedByDateAdded(ascending);
            return Ok(properties);
        }

        // Get properties by user ID
        [HttpGet("user/{userId}")]
        public IActionResult GetPropertiesByUserId(int userId)
        {
            var properties = _propertyService.GetPropertiesByUserId(userId);
            return Ok(properties);
        }
    }
}
