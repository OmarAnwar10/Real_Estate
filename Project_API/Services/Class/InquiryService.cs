using Application.ServiceContracts;
using API_Project.DataAccessContracts;
using application.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using API_Project.DataAccess.Models;
using Application.DataAccessContracts;

namespace Application.Services
{
    public class InquiryService : IInquiryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InquiryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Inquiry> GetAllInquiries()
        {
            try
            {
                return _unitOfWork.Inquiry.GetAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء جلب جميع الاستفسارات.", ex);
            }
        }

        public Inquiry GetInquiryById(int id)
        {
            try
            {
                var inquiry = _unitOfWork.Inquiry.Get(id);
                if (inquiry == null)
                {
                    throw new KeyNotFoundException("الاستفسار غير موجود.");
                }
                return inquiry;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"حدث خطأ أثناء جلب الاستفسار بالمعرف {id}.", ex);
            }
        }

        public IEnumerable<Inquiry> GetInquiriesByUserId(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("معرف المستخدم غير صحيح.", nameof(userId));
            }

            try
            {
                return _unitOfWork.Inquiry.GetAll().Where(i => i.UserId == userId).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء جلب استفسارات المستخدم.", ex);
            }
        }

        public IEnumerable<Inquiry> GetInquiriesByPropertyId(int propertyId)
        {
            if (propertyId <= 0)
            {
                throw new ArgumentException("معرف العقار غير صحيح.", nameof(propertyId));
            }

            try
            {
                return _unitOfWork.Inquiry.GetAll().Where(i => i.PropertyId == propertyId).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء جلب استفسارات العقار.", ex);
            }
        }

        public void CreateInquiry(Inquiry inquiry)
        {
            if (inquiry == null)
            {
                throw new ArgumentNullException(nameof(inquiry), "الاستفسار لا يمكن أن يكون null.");
            }

            try
            {
                _unitOfWork.Inquiry.Insert(inquiry);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء إنشاء الاستفسار.", ex);
            }
        }

        public void UpdateInquiry(Inquiry inquiry)
        {
            if (inquiry == null)
            {
                throw new ArgumentNullException(nameof(inquiry), "الاستفسار لا يمكن أن يكون null.");
            }

            try
            {
                var existingInquiry = _unitOfWork.Inquiry.Get(inquiry.Id);
                if (existingInquiry == null)
                {
                    throw new KeyNotFoundException("الاستفسار غير موجود.");
                }

                _unitOfWork.Inquiry.Update(inquiry);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء تحديث الاستفسار.", ex);
            }
        }

        public void DeleteInquiry(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("معرف الاستفسار غير صحيح.", nameof(id));
            }

            try
            {
                var inquiry = _unitOfWork.Inquiry.Get(id);
                if (inquiry == null)
                {
                    throw new KeyNotFoundException("الاستفسار غير موجود.");
                }

                _unitOfWork.Inquiry.Delete(id);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء حذف الاستفسار.", ex);
            }
        }

        public IEnumerable<Inquiry> GetInquiriesByDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("تاريخ البدء يجب أن يكون قبل تاريخ الانتهاء.");
            }

            try
            {
                return _unitOfWork.Inquiry.GetAll().Where(i => i.DateSent >= startDate && i.DateSent <= endDate).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء جلب الاستفسارات بناءً على النطاق الزمني.", ex);
            }
        }
    }
}
