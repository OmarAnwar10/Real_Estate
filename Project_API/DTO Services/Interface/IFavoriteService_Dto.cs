using API_Project.DataAccess.DTOs;
using Application.ServiceContracts;
using System.Collections.Generic;

namespace Application.ServiceContracts
{
    public interface IFavoriteService_Dto
    {
        IEnumerable<FavoriteDto> GetFavoritesByUserId(int userId); // الحصول على المفضلات بناءً على معرف المستخدم
        void AddToFavorites(FavoriteDto favoriteDto); // إضافة إلى المفضلات
        void RemoveFromFavorites(int userId, int propertyId); // إزالة من المفضلات
        bool IsFavorite(int userId, int propertyId); // التحقق مما إذا كان العقار مفضلاً
        IEnumerable<PropertyDto> GetFavoriteProperties(int userId); // الحصول على خصائص المفضلة
        void ClearFavorites(int userId); // مسح المفضلات
    }
}
