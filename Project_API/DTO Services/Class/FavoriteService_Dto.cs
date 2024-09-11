using Application.ServiceContracts;
using API_Project.DataAccessContracts;
using application.DataAccess.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using API_Project.DataAccess.DTOs;
using API_Project.DataAccess.Models;
using Application.DataAccessContracts;

namespace Application.Services
{
    public class FavoriteService_Dto : IFavoriteService_Dto
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FavoriteService_Dto(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<FavoriteDto> GetFavoritesByUserId(int userId)
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

                return _mapper.Map<IEnumerable<FavoriteDto>>(favorites);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving favorites.", ex);
            }
        }

        public void AddToFavorites(FavoriteDto favoriteDto)
        {
            ValidateFavorite(favoriteDto);

            try
            {
                if (IsFavorite(favoriteDto.UserId, favoriteDto.PropertyId))
                {
                    throw new InvalidOperationException("Property is already in favorites.");
                }

                var favorite = _mapper.Map<Favorite>(favoriteDto);
                _unitOfWork.Favorite.Insert(favorite);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
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
                throw new ApplicationException("An error occurred while checking if the property is a favorite.", ex);
            }
        }

        public IEnumerable<PropertyDto> GetFavoriteProperties(int userId)
        {
            try
            {
                var favorites = GetFavoritesByUserId(userId);
                var propertyIds = favorites.Select(f => f.PropertyId);

                var properties = _unitOfWork.Property.GetAll()
                    .Where(p => propertyIds.Contains(p.Id))
                    .ToList();

                return _mapper.Map<IEnumerable<PropertyDto>>(properties);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving favorite properties.", ex);
            }
        }

        public void ClearFavorites(int userId)
        {
            try
            {
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

        // Private method to validate favorite
        private void ValidateFavorite(FavoriteDto favoriteDto)
        {
            if (favoriteDto == null)
                throw new ArgumentNullException(nameof(favoriteDto));

            if (favoriteDto.UserId <= 0)
                throw new ArgumentException("Invalid user ID.", nameof(favoriteDto.UserId));

            if (favoriteDto.PropertyId <= 0)
                throw new ArgumentException("Invalid property ID.", nameof(favoriteDto.PropertyId));

            // Add any additional validations as needed
        }
    }
}
