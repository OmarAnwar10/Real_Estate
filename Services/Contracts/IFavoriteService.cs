using _Services.Models.Favorite;
using application.DataAccess.Models;

namespace _Services.Contracts
{
    public interface IFavoriteService
    {
        void AddToFavorites(Favorite_Add _favorite);
        void RemoveFromFavorites(int userId, int propertyId);
        void ClearFavorites(int userId);
        bool IsFavorite(int userId, int propertyId);
    }
}
