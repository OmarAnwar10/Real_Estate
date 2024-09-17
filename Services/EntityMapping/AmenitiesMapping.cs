using _DataAccess.Models;
using _Services.Models.Amenities;

namespace _Services.EntityMapping
{
    public static class AmenitiesMapping
    {
        public static Amenities MapToAmenities(this Amenities_Create amenities)
        {
            return new Amenities
            {
                HasBalcony = amenities.HasBalcony,
                HasCentralHeating = amenities.HasCentralHeating,
                HasElevator = amenities.HasElevator,
                HasGarage = amenities.HasGarage,
                HasGarden = amenities.HasGarden,
                HasParking = amenities.HasParking,
                HasPool = amenities.HasPool,
                IsFurnished = amenities.IsFurnished,
                Laundry_Room = amenities.Laundry_Room,
                Two_Stories = amenities.Two_Stories
            };
        }

        public static Amenities_Out MapToAmenitiesOut(this Amenities amenities)
        {
            return new Amenities_Out
            {
                HasBalcony = amenities.HasBalcony,
                HasCentralHeating = amenities.HasCentralHeating,
                HasElevator = amenities.HasElevator,
                HasGarage = amenities.HasGarage,
                HasGarden = amenities.HasGarden,
                HasParking = amenities.HasParking,
                HasPool = amenities.HasPool,
                IsFurnished = amenities.IsFurnished,
                Laundry_Room = amenities.Laundry_Room,
                Two_Stories = amenities.Two_Stories
            };
        }
    }
}
