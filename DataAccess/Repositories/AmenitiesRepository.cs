using _DataAccess.Contracts;
using _DataAccess.Models;
using API_Project.DataAccess.Repositories;
using application.DataAccess;

namespace _DataAccess.Repositories
{
    internal class AmenitiesRepository : BaseRepository<Amenities>, IAmenitiesRepository
    {
        public AmenitiesRepository(AppDbContext context) : base(context)
        {
        }
    }
}
