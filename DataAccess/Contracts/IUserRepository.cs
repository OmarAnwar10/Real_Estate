using application.DataAccess.Models;
namespace Application.DataAccessContracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User? GetByEmail(string email);
        User? GetByEmailAndPassword(string email, string password);
        IEnumerable<Property> GetMyProperties(int UserId);
        IEnumerable<Property?> GetMyFavoriteProperties(int UserId);
    }
}
