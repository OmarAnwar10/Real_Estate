using API_Project.DataAccess.Models;
using API_Project.DataAccessContracts;
using application.DataAccess;

namespace API_Project.DataAccess.Repositories
{
    public class FavoriteRepository : BaseRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
