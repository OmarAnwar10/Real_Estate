using _Services.Models.Amenities;

namespace _Services.Contracts
{
    public interface IAmenitiesService
    {
        void CreateAmenities(Amenities_Create Amenities);
    }
}
