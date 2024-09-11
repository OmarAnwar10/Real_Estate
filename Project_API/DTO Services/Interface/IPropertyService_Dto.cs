using application.DataAccess.Models;
using System.Collections.Generic;

using Application.ServiceContracts;
using System.Collections.Generic;
using API_Project.DataAccess.DTOs;
using API_Project.DataAccess.DTOs_Models;

namespace Application.ServiceContracts
{
    public interface IPropertyService_Dto
    {
        IEnumerable<PropertyDto> GetAllProperties(); // الحصول على جميع العقارات
        PropertyDto GetPropertyById(int id); // الحصول على عقار بناءً على المعرف
        void CreateProperty(PropertywithAmenitiesDto propertyDto); // إنشاء عقار جديد
        void UpdateProperty(int id, PropertywithAmenitiesDto propertyDto); // تحديث عقار موجود
        void DeleteProperty(int id); // حذف عقار بناءً على المعرف
        IEnumerable<PropertyDto> GetPropertiesByPrice(decimal minPrice, decimal maxPrice); // الحصول على عقارات بناءً على نطاق السعر
        IEnumerable<PropertyDto> SearchProperties(string searchTerm); // البحث عن العقارات بناءً على مصطلح بحث
        IEnumerable<PropertyDto> FilterProperties(string location = null, string propertyType = null, int? minBedrooms = null, int? maxBedrooms = null, int? minBathrooms = null, int? maxBathrooms = null); // تصفية العقارات بناءً على معايير متعددة
        IEnumerable<PropertyDto> GetPropertiesOrderedByPrice(bool ascending = true); // الحصول على عقارات مرتبة بناءً على السعر
        IEnumerable<PropertyDto> GetPropertiesOrderedByDateAdded(bool ascending = true); // الحصول على عقارات مرتبة بناءً على تاريخ الإضافة
        IEnumerable<PropertyDto> GetPropertiesByUserId(int userId); // الحصول على العقارات التي يمتلكها مستخدم معين
        IEnumerable<PropertyDto> GetPropertiesOrderedByDate(); // الحصول على العقارات مرتبة حسب تاريخ الإضافة
    }
}
