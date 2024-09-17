using _Services.Contracts;
using _Services.EntityMapping;
using _Services.Models.Amenities;
using Application.DataAccessContracts;

namespace _Services.Services
{
    internal class AmenitiesService : IAmenitiesService
    {

        private readonly IUnitOfWork _unitOfWork;

        public AmenitiesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateAmenities(Amenities_Create _amenities)
        {

            var AllAmenities = _unitOfWork.Amenities.GetAll().ToList();

            foreach (var amenity in AllAmenities)
                if (
                    (_amenities.HasPool == amenity.HasPool) && (_amenities.HasBalcony == amenity.HasBalcony) &&
                    (_amenities.HasParking == amenity.HasParking) && (_amenities.Two_Stories == amenity.Two_Stories) &&
                    (_amenities.HasGarage == amenity.HasGarage) && (_amenities.HasBalcony == amenity.HasBalcony) &&
                    (_amenities.HasCentralHeating == amenity.HasCentralHeating) && (_amenities.HasElevator == amenity.HasElevator) &&
                    (_amenities.IsFurnished == amenity.IsFurnished)
                    ) return;

            _unitOfWork.Amenities.Insert(AmenitiesMapping.MapToAmenities(_amenities));
            _unitOfWork.Save();
        }
    }
}
