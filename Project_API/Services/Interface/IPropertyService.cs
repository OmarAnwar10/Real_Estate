using application.DataAccess.Models;
using System.Collections.Generic;

namespace Application.ServiceContracts
{
    public interface IPropertyService
    {
        IEnumerable<Property> GetAllProperties(); // الحصول على جميع العقارات
        Property GetPropertyById(int id); // الحصول على عقار بناءً على المعرف
        void CreateProperty(Property property); // إنشاء عقار جديد
        void UpdateProperty(Property property); // تحديث عقار موجود
        void DeleteProperty(int id); // حذف عقار بناءً على المعرف
        IEnumerable<Property> GetPropertiesByPrice(decimal minPrice, decimal maxPrice); // الحصول على عقارات بناءً على نطاق السعر

        // طرق بحث وتصفية إضافية
        IEnumerable<Property> SearchProperties(string searchTerm); // البحث عن العقارات بناءً على مصطلح بحث (مثل الموقع أو العنوان)
        IEnumerable<Property> FilterProperties(string location = null, string propertyType = null, int? minBedrooms = null, int? maxBedrooms = null, int? minBathrooms = null, int? maxBathrooms = null); // تصفية العقارات بناءً على معايير متعددة

        // طرق ترتيب
        IEnumerable<Property> GetPropertiesOrderedByPrice(bool ascending = true); // الحصول على عقارات مرتبة بناءً على السعر
        IEnumerable<Property> GetPropertiesOrderedByDateAdded(bool ascending = true); // الحصول على عقارات مرتبة بناءً على تاريخ الإضافة


        IEnumerable<Property> GetPropertiesOrderedByDate(); // الحصول على العقارات مرتبة حسب تاريخ الإضافة
        IEnumerable<Property> GetPropertiesByUserId(int userId); // الحصول على العقارات التي يمتلكها مستخدم معين

    }
}
