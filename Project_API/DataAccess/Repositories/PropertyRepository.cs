using application.DataAccess;
using application.DataAccess.Models;
using Application.DataAccessContracts;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace API_Project.DataAccess.Repositories
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {

        public PropertyRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Property> GetPropertiesByPrice(decimal minPrice, decimal maxPrice)
        {
            return _dbSet.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
        }

    }
}
