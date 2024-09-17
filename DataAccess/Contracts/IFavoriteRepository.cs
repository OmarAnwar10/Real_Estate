using API_Project.DataAccess.Models;
using application.DataAccess.Models;
using Application.DataAccessContracts;

namespace API_Project.DataAccessContracts
{
    public interface IFavoriteRepository : IBaseRepository<Favorite>
    {
        IEnumerable<Property> GetAllProperies(int userId);
    }
}
