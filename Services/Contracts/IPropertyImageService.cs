using _Services.Models.PropertyImage;

namespace _Services.Contracts
{
    public interface IPropertyImageService
    {
        void CreatePropertyImage(int propertyId, PropertyImage_Create image);
        void UpdateAllPropertyImages(int propertyId, IEnumerable<PropertyImage_Create> images);
        void UpdatePropertyImage(int propertyId, int imageId, PropertyImage_Create image);
    }
}
