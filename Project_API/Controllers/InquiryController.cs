using _Services.Contracts;
using _Services.Models.Inquiry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquiryController : ControllerBase
    {
        private readonly IInquiryService _inquiryService;

        public InquiryController(IInquiryService inquiryService)
        {
            _inquiryService = inquiryService;
        }


        // Create a new inquiry
        [HttpPost]
        public IActionResult CreateInquiry([FromBody] Inquiry_Create _inquiry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _inquiryService.CreateInquiry(_inquiry);
            return Ok("Inquiry created successfully.");
        }

        // Update an existing inquiry
        [HttpPut("{id}")]
        public IActionResult UpdateInquiry(int id, [FromBody] Inquiry_Update _inquiry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //inquiryDto.Id = id; // Ensure ID is set for update
            _inquiryService.UpdateInquiry(id, _inquiry);
            return Ok("Inquiry updated successfully.");
        }

        // Delete an inquiry by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteInquiry(int id)
        {
            try
            {
                _inquiryService.DeleteInquiry(id);
                return Ok("Inquiry deleted successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
