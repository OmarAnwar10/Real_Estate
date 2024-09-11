using API_Project.DataAccess.DTOs;
using API_Project.DataAccess.DTOs_Models;
using Application.ServiceContracts;
using System.Collections.Generic;

namespace Application.ServiceContracts
{
    public interface IUserService_Dto
    {
        IEnumerable<UserDto> GetAllUsers(); // الحصول على جميع المستخدمين
        UserDto GetUserById(int id); // الحصول على مستخدم بناءً على المعرف
        void CreateUser(UserWithOutIdDto userDto); // إنشاء مستخدم جديد
        void UpdateUser(int id, UserWithOutIdDto userDto); // تحديث مستخدم موجود
        void DeleteUser(int id); // حذف مستخدم بناءً على المعرف
        UserDto AuthenticateUser(string email, string password); // التحقق من صحة تسجيل دخول المستخدم

        IEnumerable<PropertyDto> GetUserProperties(int userId); // الحصول على العقارات التي يمتلكها مستخدم معين
        IEnumerable<InquiryDto> GetUserInquiries(int userId); // الحصول على الاستفسارات المرسلة من قبل مستخدم معين
        IEnumerable<FavoriteDto> GetUserFavorites(int userId); // الحصول على العقارات المفضلة لمستخدم معين
        void UpdateUserPassword(int userId, string newPassword); // تحديث كلمة مرور المستخدم
    }
}
