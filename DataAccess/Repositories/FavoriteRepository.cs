using API_Project.DataAccess.Models;
using API_Project.DataAccessContracts;
using application.DataAccess;
using application.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Project.DataAccess.Repositories
{
    internal class FavoriteRepository : BaseRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(AppDbContext context) : base(context)
        {

        }
        public IEnumerable<Property> GetAllProperies(int userId)
        {
            
            var propertiesId = _dbSet
                .Where(x => x.UserId == userId)
                .Select(x => x.PropertyId)
                .ToList();
            
            var properties = _db.Properties
                .Include(x => x.Images)
                .Include(x => x.Amenities)
                .Where(x => propertiesId.Contains(x.Id))
                .ToList();

            return properties;
        }
    }
}
