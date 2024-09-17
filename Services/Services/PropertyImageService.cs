using _DataAccess.Models;
using _Services.Contracts;
using _Services.Models.PropertyImage;
using Application.DataAccessContracts;

namespace _Services.Services
{
    internal class PropertyImageService : IPropertyImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PropertyImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void CreatePropertyImage(int propertyId, PropertyImage_Create image)
        {
            var propertyImage = new PropertyImage
            {
                Url = image.ImageUrl,
                PropertyId = propertyId
            };

            _unitOfWork.PropertyImage.Insert(propertyImage);
            _unitOfWork.Save();
        }

        public void UpdateAllPropertyImages(int propertyId, IEnumerable<PropertyImage_Create> images)
        {
            try
            {
                var property = _unitOfWork.Property.GetById(propertyId);
                if (property == null)
                {
                    throw new KeyNotFoundException("Property not found.");
                }
                _unitOfWork.PropertyImage.UpdateAllPropertyImages(propertyId, images.Select(i => i.ImageUrl));
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while updating property images.", ex);
            }
        }

        public void UpdatePropertyImage(int propertyId, int imageId, PropertyImage_Create image)
        {
            try
            {
                var property = _unitOfWork.Property.GetById(propertyId);
                if (property == null)
                {
                    throw new KeyNotFoundException("Property not found.");
                }
                _unitOfWork.PropertyImage.UpdatePropertyImage(propertyId, imageId, image.ImageUrl);
            }
            catch (Exception ex)
            {
                // Log exception here
                throw new ApplicationException("An error occurred while updating property image.", ex);
            }
        }
    }
}
