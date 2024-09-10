using API_Project.DataAccess.Models;
using application.DataAccess.Models;
using System.Collections.Generic;

namespace Application.ServiceContracts
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();                  // الحصول على جميع المستخدمين
        User GetUserById(int id);                         // الحصول على مستخدم بناءً على المعرف
        void CreateUser(User user);                       // إنشاء مستخدم جديد
        void UpdateUser(User user);                       // تحديث مستخدم موجود
        void DeleteUser(int id);                          // حذف مستخدم بناءً على المعرف
        User AuthenticateUser(string email, string password); // التحقق من صحة تسجيل دخول المستخدم


       
        IEnumerable<Property> GetUserProperties(int userId); // الحصول على العقارات التي يمتلكها مستخدم معين
        IEnumerable<Inquiry> GetUserInquiries(int userId); // الحصول على الاستفسارات المرسلة من قبل مستخدم معين
        IEnumerable<Favorite> GetUserFavorites(int userId); // الحصول على العقارات المفضلة لمستخدم معين
        void UpdateUserPassword(int userId, string newPassword); // تحديث كلمة مرور المستخدم
    }
}
