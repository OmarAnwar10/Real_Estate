using API_Project.DataAccess.Models;
using application.DataAccess.Models;
using System.Collections.Generic;

namespace Application.ServiceContracts
{
    public interface IFavoriteService
    {
        IEnumerable<Favorite> GetFavoritesByUserId(int userId); // الحصول على قائمة المفضلات لمستخدم بناءً على المعرف
        void AddToFavorites(Favorite favorite);                 // إضافة عقار إلى قائمة المفضلات
        void RemoveFromFavorites(int userId, int propertyId);    // إزالة عقار من قائمة المفضلات
        bool IsFavorite(int userId, int propertyId);             // التحقق مما إذا كان العقار في قائمة المفضلات



        IEnumerable<Property> GetFavoriteProperties(int userId); // الحصول على العقارات المفضلة لمستخدم معين
        void ClearFavorites(int userId); // مسح جميع المفضلات لمستخدم معين
    }
}
