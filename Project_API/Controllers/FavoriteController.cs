using _Services.Contracts;
using _Services.Models.Favorite;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }


        // Add a property to favorites
        [HttpPost]
        public IActionResult AddToFavorites([FromBody] Favorite_Add _favorite)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _favoriteService.AddToFavorites(_favorite);
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
    }
}
