using Microsoft.AspNetCore.Mvc;
using Application.ServiceContracts;
using API_Project.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using API_Project.DataAccess.DTOs_Models;
using Application.Services;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquiryController : ControllerBase
    {
        private readonly IInquiryService_Dto _inquiryService;

        public InquiryController(IInquiryService_Dto inquiryService)
        {
            _inquiryService = inquiryService;
        }

        // Get all inquiries
        [HttpGet]
        public IActionResult GetAllInquiries()
        {
            var inquiries = _inquiryService.GetAllInquiries();
            return Ok(inquiries);
        }

        // Get inquiry by ID
        [HttpGet("{id}")]
        public IActionResult GetInquiryById(int id)
        {
            var inquiry = _inquiryService.GetInquiryById(id);
            if (inquiry == null)
                return NotFound("Inquiry not found.");

            return Ok(inquiry);
        }

        // Get inquiries by user ID
        [HttpGet("user/{userId}")]
        public IActionResult GetInquiriesByUserId(int userId)
        {
            try
            {
                var inquiries = _inquiryService.GetInquiriesByUserId(userId);
                return Ok(inquiries);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get inquiries by property ID
        [HttpGet("property/{propertyId}")]
        public IActionResult GetInquiriesByPropertyId(int propertyId)
        {
            try
            {
                var inquiries = _inquiryService.GetInquiriesByPropertyId(propertyId);
                return Ok(inquiries);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Create a new inquiry
        [HttpPost]
        public IActionResult CreateInquiry([FromBody] InquiryDto inquiryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _inquiryService.CreateInquiry(inquiryDto);
            return Ok("Inquiry created successfully.");
        }

        // Update an existing inquiry
        [HttpPut("{id}")]
        public IActionResult UpdateInquiry(int id, [FromBody] InquiryDto inquiryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //inquiryDto.Id = id; // Ensure ID is set for update
            _inquiryService.UpdateInquiry(id, inquiryDto);
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

        // Get inquiries by date range
        [HttpGet("dateRange")]
        public IActionResult GetInquiriesByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                var inquiries = _inquiryService.GetInquiriesByDateRange(startDate, endDate);
                return Ok(inquiries);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
