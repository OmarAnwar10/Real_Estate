using application.DataAccess.Models;

namespace Application.DataAccessContracts
{
    public interface IPropertyRepository : IBaseRepository<Property>
    {
        public IEnumerable<Property> GetPropertiesByPrice(decimal minPrice, decimal maxPrice);
    }
}
