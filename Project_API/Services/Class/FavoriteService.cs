using Application.ServiceContracts;
using API_Project.DataAccess.Models;
using application.DataAccess.Models;
using Application.DataAccessContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FavoriteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Favorite> GetFavoritesByUserId(int userId)
        {
            try
            {
                var favorites = _unitOfWork.Favorite.GetAll()
                    .Where(f => f.UserId == userId)
                    .ToList();

                if (favorites == null || !favorites.Any())
                {
                    throw new KeyNotFoundException("No favorites found for this user.");
                }

                return favorites;
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving favorites.", ex);
            }
        }

        public void AddToFavorites(Favorite favorite)
        {
            ValidateFavorite(favorite);

            try
            {
                if (IsFavorite(favorite.UserId, favorite.PropertyId))
                {
                    throw new InvalidOperationException("Property is already in favorites.");
                }

                _unitOfWork.Favorite.Insert(favorite);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while adding to favorites.", ex);
            }
        }

        public void RemoveFromFavorites(int userId, int propertyId)
        {
            try
            {
                var favorite = _unitOfWork.Favorite.GetAll()
                    .FirstOrDefault(f => f.UserId == userId && f.PropertyId == propertyId);

                if (favorite == null)
                {
                    throw new KeyNotFoundException("Favorite not found.");
                }

                _unitOfWork.Favorite.Delete(favorite.Id);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while removing from favorites.", ex);
            }
        }

        public bool IsFavorite(int userId, int propertyId)
        {
            try
            {
                return _unitOfWork.Favorite.GetAll()
                    .Any(f => f.UserId == userId && f.PropertyId == propertyId);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while checking if the property is a favorite.", ex);
            }
        }

        public IEnumerable<Property> GetFavoriteProperties(int userId)
        {
            try
            {
                var favorites = GetFavoritesByUserId(userId);
                var propertyIds = favorites.Select(f => f.PropertyId);

                return _unitOfWork.Property.GetAll()
                    .Where(p => propertyIds.Contains(p.Id))
                    .ToList();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving favorite properties.", ex);
            }
        }

        public void ClearFavorites(int userId)
        {
            try
            {
                var favorites = GetFavoritesByUserId(userId);
                foreach (var favorite in favorites)
                {
                    _unitOfWork.Favorite.Delete(favorite.Id);
                }

                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while clearing favorites.", ex);
            }
        }

        // Private method to validate favorite
        private void ValidateFavorite(Favorite favorite)
        {
            if (favorite == null)
                throw new ArgumentNullException(nameof(favorite));

            if (favorite.UserId <= 0)
                throw new ArgumentException("Invalid user ID.", nameof(favorite.UserId));

            if (favorite.PropertyId <= 0)
                throw new ArgumentException("Invalid property ID.", nameof(favorite.PropertyId));

            // Add any additional validations as needed
        }
    }
}
