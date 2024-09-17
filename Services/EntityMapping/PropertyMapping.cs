using _Services.Models.Property;
using application.DataAccess.Models;
using _Services.Models.City;

namespace _Services.EntityMapping
{
    public static class PropertyMapping
    {
        public static Property MapToProperty(Property_Create property, int Amenities_Id, int cityId)
        {
            return new Property
            {
                OwnerId = property.OwnerId,
                Title = property.Title,
                Description = property.Description,
                Price = property.Price,
                Location = property.Location,
                CityId = cityId,
                Area = property.Area,
                PropertyType = property.PropertyType,
                Bedrooms = property.Bedrooms,
                Bathrooms = property.Bathrooms,
                DateAdded = DateTime.Now,
                YearBuilt = property.YearBuilt,
                Status = property.Status,
                AmenitiesId = Amenities_Id,
            };
        }

        public static IEnumerable<Property_GetAll_Func> MapToPropertyGetAll(IEnumerable<Property> properties)
        {

            return properties.Select(p => new Property_GetAll_Func
            {
                Id = p.Id,
                OwnerId = p.OwnerId,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                Location = p.Location,
                City = p.City.Name,
                Area = p.Area,
                PropertyType = p.PropertyType,
                Bedrooms = p.Bedrooms,
                Bathrooms = p.Bathrooms,
                YearBuilt = p.YearBuilt,
                DateAdded = p.DateAdded,
                Status = p.Status,
                Amenities = AmenitiesMapping.MapToAmenitiesOut(p.Amenities),
                Image = p.Images.Select(i => i.Url).First()?.ToString() ?? "No Image"
            });

        }



        public static Property_AllInfo MapToPropertyAllInfo(Property property)
        {
            return new Property_AllInfo
            {
                Id = property.Id,
                OwnerId = property.OwnerId,
                Owner = UserMapping.UserToUser_Basic(property.Owner),
                Title = property.Title,
                Description = property.Description,
                Price = property.Price,
                Location = property.Location,
                City = property.City.Name,
                Area = property.Area,
                PropertyType = property.PropertyType,
                Bedrooms = property.Bedrooms,
                Bathrooms = property.Bathrooms,
                YearBuilt = property.YearBuilt,
                DateAdded = property.DateAdded,
                Status = property.Status,
                Amenities = AmenitiesMapping.MapToAmenitiesOut(property.Amenities),
                Image = property.Images.Select(i => i.Url).ToList()

            };
        }


    }
}
