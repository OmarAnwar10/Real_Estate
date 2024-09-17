using _DataAccess.Models;
using Application.DataAccessContracts;

namespace _DataAccess.Contracts
{
    public interface IPropertyImageRepository : IBaseRepository<PropertyImage>
    {
        void UpdateAllPropertyImages(int propertyId, IEnumerable<string> images);
        void UpdatePropertyImage(int propertyId, int imageId, string image);
    }
}
