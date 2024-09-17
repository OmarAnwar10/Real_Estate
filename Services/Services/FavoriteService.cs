using _Services.Contracts;
using _Services.Models.Favorite;
using _Services.Models.User;
using API_Project.DataAccess.Models;
using Application.DataAccessContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Services.Services
{
    internal class FavoriteService : IFavoriteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        public FavoriteService(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public void AddToFavorites(Favorite_Add _favorite)
        {

            ValidateToAddFavorite(_favorite);

            Favorite favorite = new Favorite
            {
                UserId = _favorite.UserId,
                PropertyId = _favorite.PropertyId
            };

            _unitOfWork.Favorite.Insert(favorite);
            _unitOfWork.Save();
        }

        public void RemoveFromFavorites(int userId, int propertyId)
        {
            ValidateToRemoveFavorite(userId, propertyId);

            var favorite = _unitOfWork.Favorite.GetAll().FirstOrDefault(f => f.UserId == userId && f.PropertyId == f.PropertyId);

            _unitOfWork.Favorite.Delete(favorite.Id);
            _unitOfWork.Save();

        }
        public void ClearFavorites(int userId)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                if (user == null)
                    throw new InvalidOperationException("User not found.");

                var favorites = _unitOfWork.Favorite.GetAll()
                   .Where(f => f.UserId == userId)
                   .ToList();

                foreach (var favorite in favorites)
                {
                    _unitOfWork.Favorite.Delete(favorite.Id);
                }

                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while clearing favorites.", ex);
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
                throw new ApplicationException("An error occurred while checking if the property is a favorite.", ex);
            }
        }

        private void ValidateToAddFavorite(Favorite_Add _favorite)
        {
            if (_favorite.UserId == 0 || _favorite.PropertyId == 0)
                throw new InvalidOperationException("Invalid data.");

            var property = _unitOfWork.Property.GetById(_favorite.PropertyId);
            if (property == null)
                throw new InvalidOperationException("Property not found.");

            var user = _userService.GetUserById(_favorite.UserId);
            if (user == null)
                throw new InvalidOperationException("User not found.");

            var userProperty = _userService.GetUserProperties(_favorite.UserId).FirstOrDefault(p => p.Id == _favorite.PropertyId);
            if (userProperty != null)
                throw new InvalidOperationException("You can't add your own property to favorites.");

            var userFavorite = _userService.GetUserFavoritesProperty(_favorite.UserId).FirstOrDefault(p => p.Id == _favorite.PropertyId);
            if (userFavorite != null)
                throw new InvalidOperationException("Property already in favorites.");
        }

        private void ValidateToRemoveFavorite(int userId, int propertyId)
        {
            if (userId == 0 || propertyId == 0)
                throw new InvalidOperationException("Invalid data.");

            var property = _unitOfWork.Property.GetById(propertyId);
            if (property == null)
                throw new InvalidOperationException("Property not found.");

            var user = _userService.GetUserById(userId);
            if (user == null)
                throw new InvalidOperationException("User not found.");

            var userFavorite = _userService.GetUserFavoritesProperty(userId).FirstOrDefault(p => p.Id == propertyId);
            if (userFavorite == null)
                throw new InvalidOperationException("Property not in favorites.");
        }
    }
}
