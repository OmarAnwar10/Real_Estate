using Microsoft.AspNetCore.Mvc;
using Application.ServiceContracts;
using API_Project.DataAccess.DTOs;
using System;
using System.Collections.Generic;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService_Dto _favoriteService;

        public FavoriteController(IFavoriteService_Dto favoriteService)
        {
            _favoriteService = favoriteService;
        }

        // Get favorites by user ID
        [HttpGet("user/{userId}")]
        public IActionResult GetFavoritesByUserId(int userId)
        {
            try
            {
                var favorites = _favoriteService.GetFavoritesByUserId(userId);
                return Ok(favorites);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Add a property to favorites
        [HttpPost]
        public IActionResult AddToFavorites([FromBody] FavoriteDto favoriteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _favoriteService.AddToFavorites(favoriteDto);
                return Ok("Property added to favorites.");
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Remove a property from favorites
        [HttpDelete("user/{userId}/property/{propertyId}")]
        public IActionResult RemoveFromFavorites(int userId, int propertyId)
        {
            try
            {
                _favoriteService.RemoveFromFavorites(userId, propertyId);
                return Ok("Property removed from favorites.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Check if a property is in favorites
        [HttpGet("user/{userId}/property/{propertyId}/exists")]
        public IActionResult IsFavorite(int userId, int propertyId)
        {
            try
            {
                bool isFavorite = _favoriteService.IsFavorite(userId, propertyId);
                return Ok(isFavorite);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Get favorite properties for a user
        [HttpGet("user/{userId}/properties")]
        public IActionResult GetFavoriteProperties(int userId)
        {
            try
            {
                var properties = _favoriteService.GetFavoriteProperties(userId);
                return Ok(properties);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Clear all favorites for a user
        [HttpDelete("user/{userId}/clear")]
        public IActionResult ClearFavorites(int userId)
        {
            try
            {
                _favoriteService.ClearFavorites(userId);
                return Ok("Favorites cleared.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
