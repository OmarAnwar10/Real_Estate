using application.DataAccess.Models;

namespace Application.DataAccessContracts
{
    public interface IPropertyRepository : IBaseRepository<Property>
    {
        //public IEnumerable<Property> GetPropertiesByPrice(decimal minPrice, decimal maxPrice);

        IEnumerable<Property> GetPropertiesWithFilter(string? keyWord = null, string? city = null, Status status = Status.buy,

                                                       decimal? minPrice = null, decimal? maxPrice = null,
                                                       double? minArea = null, double? maxArea = null,
                                                       int? minBaths = null, int? maxBaths = null, int? minBed = null, int? maxBed = null,

                                                       bool HasGarage = false, bool Two_Stories = false, bool Laundry_Room = false,
                                                       bool HasPool = false, bool HasGarden = false, bool HasElevator = false,
                                                       bool HasBalcony = false, bool HasParking = false, bool HasCentralHeating = false, bool IsFurnished = false);

        IEnumerable<Property> GetPropertiesWithFilterOrderedByPrice(string? keyWord = null, string? city = null, Status status = Status.buy,

                                               decimal? minPrice = null, decimal? maxPrice = null,
                                               double? minArea = null, double? maxArea = null,
                                               int? minBaths = null, int? maxBaths = null, int? minBed = null, int? maxBed = null,

                                               bool HasGarage = false, bool Two_Stories = false, bool Laundry_Room = false,
                                               bool HasPool = false, bool HasGarden = false, bool HasElevator = false,
                                               bool HasBalcony = false, bool HasParking = false, bool HasCentralHeating = false, bool IsFurnished = false,

                                               bool ascending = true);

        IEnumerable<Property> GetPropertiesWithFilterOrderedByDateAdded(string? keyWord = null, string? city = null, Status status = Status.buy,

                                               decimal? minPrice = null, decimal? maxPrice = null,
                                               double? minArea = null, double? maxArea = null,
                                               int? minBaths = null, int? maxBaths = null, int? minBed = null, int? maxBed = null,

                                               bool HasGarage = false, bool Two_Stories = false, bool Laundry_Room = false,
                                               bool HasPool = false, bool HasGarden = false, bool HasElevator = false,
                                               bool HasBalcony = false, bool HasParking = false, bool HasCentralHeating = false, bool IsFurnished = false,

                                               bool ascending = true);

        IEnumerable<Property> GetPropertiesByUserId(int userId);
    }
}
