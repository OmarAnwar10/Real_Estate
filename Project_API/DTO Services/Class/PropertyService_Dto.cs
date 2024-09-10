using Application.ServiceContracts;
using application.DataAccess.Models;
using Application.DataAccessContracts;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System;
using API_Project.DataAccess.DTOs;

namespace Application.Services
{
    public class PropertyService_Dto : IPropertyService_Dto
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PropertyService_Dto(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<PropertyDto> GetAllProperties()
        {
            try
            {
                var properties = _unitOfWork.Property.GetAll();
                return _mapper.Map<IEnumerable<PropertyDto>>(properties);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving properties.", ex);
            }
        }

        public PropertyDto GetPropertyById(int id)
        {
            try
            {
                var property = _unitOfWork.Property.Get(id);
                if (property == null)
                {
                    throw new KeyNotFoundException("Property not found.");
                }
                return _mapper.Map<PropertyDto>(property);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving the property.", ex);
            }
        }

        public void CreateProperty(PropertyDto propertyDto)
        {
            ValidatePropertyDto(propertyDto);

            try
            {
                var property = _mapper.Map<Property>(propertyDto);
                _unitOfWork.Property.Insert(property);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while creating the property.", ex);
            }
        }

        public void UpdateProperty(PropertyDto propertyDto)
        {
            ValidatePropertyDto(propertyDto);

            try
            {
                var existingProperty = _unitOfWork.Property.Get(propertyDto.Id);
                if (existingProperty == null)
                {
                    throw new KeyNotFoundException("Property not found.");
                }

                var property = _mapper.Map<Property>(propertyDto);
                _unitOfWork.Property.Update(property);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while updating the property.", ex);
            }
        }

        public void DeleteProperty(int id)
        {
            try
            {
                var property = _unitOfWork.Property.Get(id);
                if (property == null)
                {
                    throw new KeyNotFoundException("Property not found.");
                }

                _unitOfWork.Property.Delete(id);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while deleting the property.", ex);
            }
        }

        public IEnumerable<PropertyDto> GetPropertiesByPrice(decimal minPrice, decimal maxPrice)
        {
            try
            {
                var properties = _unitOfWork.Property.GetAll()
                    .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                    .ToList();
                return _mapper.Map<IEnumerable<PropertyDto>>(properties);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving properties by price.", ex);
            }
        }

        public IEnumerable<PropertyDto> SearchProperties(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    throw new ArgumentException("Search term cannot be null or empty.", nameof(searchTerm));
                }

                searchTerm = searchTerm.ToLower();
                var properties = _unitOfWork.Property.GetAll()
                    .Where(p => p.Title.ToLower().Contains(searchTerm) ||
                                p.Description.ToLower().Contains(searchTerm) ||
                                p.Location.ToLower().Contains(searchTerm))
                    .ToList();
                return _mapper.Map<IEnumerable<PropertyDto>>(properties);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while searching for properties.", ex);
            }
        }

        public IEnumerable<PropertyDto> FilterProperties(
            string location = null,
            string propertyType = null,
            int? minBedrooms = null,
            int? maxBedrooms = null,
            int? minBathrooms = null,
            int? maxBathrooms = null)
        {
            try
            {
                var properties = _unitOfWork.Property.GetAll().AsQueryable();

                if (!string.IsNullOrEmpty(location))
                    properties = properties.Where(p => p.Location.Contains(location));

                if (!string.IsNullOrEmpty(propertyType))
                    properties = properties.Where(p => p.PropertyType.Contains(propertyType));

                if (minBedrooms.HasValue)
                    properties = properties.Where(p => p.Bedrooms >= minBedrooms.Value);

                if (maxBedrooms.HasValue)
                    properties = properties.Where(p => p.Bedrooms <= maxBedrooms.Value);

                if (minBathrooms.HasValue)
                    properties = properties.Where(p => p.Bathrooms >= minBathrooms.Value);

                if (maxBathrooms.HasValue)
                    properties = properties.Where(p => p.Bathrooms <= maxBathrooms.Value);

                return _mapper.Map<IEnumerable<PropertyDto>>(properties.ToList());
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while filtering properties.", ex);
            }
        }

        public IEnumerable<PropertyDto> GetPropertiesOrderedByPrice(bool ascending = true)
        {
            try
            {
                var properties = ascending
                    ? _unitOfWork.Property.GetAll().OrderBy(p => p.Price).ToList()
                    : _unitOfWork.Property.GetAll().OrderByDescending(p => p.Price).ToList();
                return _mapper.Map<IEnumerable<PropertyDto>>(properties);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while ordering properties by price.", ex);
            }
        }

        public IEnumerable<PropertyDto> GetPropertiesOrderedByDateAdded(bool ascending = true)
        {
            try
            {
                var properties = ascending
                    ? _unitOfWork.Property.GetAll().OrderBy(p => p.DateAdded).ToList()
                    : _unitOfWork.Property.GetAll().OrderByDescending(p => p.DateAdded).ToList();
                return _mapper.Map<IEnumerable<PropertyDto>>(properties);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while ordering properties by date added.", ex);
            }
        }

        public IEnumerable<PropertyDto> GetPropertiesByUserId(int userId)
        {
            try
            {
                var properties = _unitOfWork.Property.GetAll()
                    .Where(p => p.OwnerId == userId)
                    .ToList();
                return _mapper.Map<IEnumerable<PropertyDto>>(properties);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving properties by user ID.", ex);
            }
        }

        public IEnumerable<PropertyDto> GetPropertiesOrderedByDate()
        {
            try
            {
                var properties = _unitOfWork.Property.GetAll()
                    .OrderBy(p => p.DateAdded)
                    .ToList();
                return _mapper.Map<IEnumerable<PropertyDto>>(properties);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while retrieving properties ordered by date.", ex);
            }
        }

        // Private method to validate property data
        private void ValidatePropertyDto(PropertyDto propertyDto)
        {
            if (propertyDto == null)
                throw new ArgumentNullException(nameof(propertyDto));

            if (string.IsNullOrEmpty(propertyDto.Title))
                throw new ArgumentException("Property title is required.", nameof(propertyDto.Title));

            if (propertyDto.Price <= 0)
                throw new ArgumentException("Property price must be greater than zero.", nameof(propertyDto.Price));

            if (propertyDto.Bedrooms < 0)
                throw new ArgumentException("Number of bedrooms cannot be negative.", nameof(propertyDto.Bedrooms));

            if (propertyDto.Bathrooms < 0)
                throw new ArgumentException("Number of bathrooms cannot be negative.", nameof(propertyDto.Bathrooms));

            // Add any additional validations as needed
        }
    }
}
