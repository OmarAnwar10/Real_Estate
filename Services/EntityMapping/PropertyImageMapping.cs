using _DataAccess.Models;
using _Services.Models.PropertyImage;

namespace _Services.EntityMapping
{
    public static class PropertyImageMapping
    {
        public static PropertyImage MapToPropertyImage(PropertyImage_Create image)
        {
            return new PropertyImage
            {
                Url = image.ImageUrl
            };
        }


    }
}
