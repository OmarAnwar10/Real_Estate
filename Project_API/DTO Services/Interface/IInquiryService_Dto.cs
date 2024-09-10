using API_Project.DataAccess.DTOs;
using Application.ServiceContracts;
using System;
using System.Collections.Generic;

namespace Application.ServiceContracts
{
    public interface IInquiryService_Dto
    {
        IEnumerable<InquiryDto> GetAllInquiries(); // الحصول على جميع الاستفسارات
        InquiryDto GetInquiryById(int id); // الحصول على استفسار بناءً على المعرف
        IEnumerable<InquiryDto> GetInquiriesByUserId(int userId); // الحصول على استفسارات بناءً على معرف المستخدم
        IEnumerable<InquiryDto> GetInquiriesByPropertyId(int propertyId); // الحصول على استفسارات بناءً على معرف العقار
        void CreateInquiry(InquiryDto inquiryDto); // إنشاء استفسار جديد
        void UpdateInquiry(InquiryDto inquiryDto); // تحديث استفسار موجود
        void DeleteInquiry(int id); // حذف استفسار بناءً على المعرف
        IEnumerable<InquiryDto> GetInquiriesByDateRange(DateTime startDate, DateTime endDate); // الحصول على الاستفسارات بناءً على النطاق الزمني
    }
}
