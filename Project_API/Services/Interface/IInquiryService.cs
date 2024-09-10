using API_Project.DataAccess.Models;
using application.DataAccess.Models;
using System.Collections.Generic;

namespace Application.ServiceContracts
{
    public interface IInquiryService
    {
        IEnumerable<Inquiry> GetAllInquiries();            // الحصول على جميع الاستفسارات
        Inquiry GetInquiryById(int id);                     // الحصول على استفسار بناءً على المعرف
        IEnumerable<Inquiry> GetInquiriesByUserId(int userId); // الحصول على الاستفسارات الخاصة بمستخدم معين
        IEnumerable<Inquiry> GetInquiriesByPropertyId(int propertyId); // الحصول على الاستفسارات الخاصة بعقار معين
        void CreateInquiry(Inquiry inquiry);               // إنشاء استفسار جديد
        void UpdateInquiry(Inquiry inquiry);               // تحديث استفسار موجود
        void DeleteInquiry(int id);                        // حذف استفسار بناءً على المعرف
        IEnumerable<Inquiry> GetInquiriesByDateRange(DateTime startDate, DateTime endDate); // الحصول على استفسارات بناءً على نطاق تاريخي

    }
}
