using _Services.Models.Property;
using _Services.Models.User;

namespace _Services.Contracts
{
    public interface IUserService
    {
        void CreateUser(User_Create user);
        void UpdateUser(int id, User_Update user);
        User_Basic GetUserById(int id);
        void DeleteUser(int id);
        User_Authenticate AuthenticateUser(string email, string password);
        void UpdateUserPassword(int userId, string newPassword);
        IEnumerable<Property_GetAll_Func> GetUserProperties(int userId);
        IEnumerable<Property_GetAll_Func> GetUserFavoritesProperty(int userId);
    }
}
