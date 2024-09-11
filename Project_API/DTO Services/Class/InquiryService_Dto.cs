using Application.ServiceContracts;
using API_Project.DataAccessContracts;
using application.DataAccess.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using API_Project.DataAccess.DTOs;
using API_Project.DataAccess.Models;
using Application.DataAccessContracts;
using API_Project.DataAccess.DTOs_Models;

namespace Application.Services
{
    public class InquiryService_Dto : IInquiryService_Dto
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InquiryService_Dto(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<InquiryDto> GetAllInquiries()
        {
            try
            {
                var inquiries = _unitOfWork.Inquiry.GetAll();
                return _mapper.Map<IEnumerable<InquiryDto>>(inquiries);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء جلب جميع الاستفسارات.", ex);
            }
        }

        public InquiryDto GetInquiryById(int id)
        {
            try
            {
                var inquiry = _unitOfWork.Inquiry.Get(id);
                if (inquiry == null)
                {
                    throw new KeyNotFoundException("الاستفسار غير موجود.");
                }
                return _mapper.Map<InquiryDto>(inquiry);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"حدث خطأ أثناء جلب الاستفسار بالمعرف {id}.", ex);
            }
        }

        public IEnumerable<InquiryDto> GetInquiriesByUserId(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("معرف المستخدم غير صحيح.", nameof(userId));
            }

            try
            {
                var inquiries = _unitOfWork.Inquiry.GetAll().Where(i => i.UserId == userId).ToList();
                return _mapper.Map<IEnumerable<InquiryDto>>(inquiries);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء جلب استفسارات المستخدم.", ex);
            }
        }

        public IEnumerable<InquiryDto> GetInquiriesByPropertyId(int propertyId)
        {
            if (propertyId <= 0)
            {
                throw new ArgumentException("معرف العقار غير صحيح.", nameof(propertyId));
            }

            try
            {
                var inquiries = _unitOfWork.Inquiry.GetAll().Where(i => i.PropertyId == propertyId).ToList();
                return _mapper.Map<IEnumerable<InquiryDto>>(inquiries);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء جلب استفسارات العقار.", ex);
            }
        }

        public void CreateInquiry(InquiryDto inquiryDto)
        {
            if (inquiryDto == null)
            {
                throw new ArgumentNullException(nameof(inquiryDto), "الاستفسار لا يمكن أن يكون null.");
            }

            try
            {
                var inquiry = _mapper.Map<Inquiry>(inquiryDto);
                _unitOfWork.Inquiry.Insert(inquiry);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء إنشاء الاستفسار.", ex);
            }
        }

        public void UpdateInquiry(int Id, InquiryDto inquiryDto)
        {
            ValidateInquiryDto(inquiryDto);

            if (inquiryDto == null)
            {
                throw new ArgumentNullException(nameof(inquiryDto), "الاستفسار لا يمكن أن يكون null.");
            }

            try
            {
                var existingInquiry = _unitOfWork.Inquiry.Get(Id);
                if (existingInquiry == null)
                {
                    throw new KeyNotFoundException("الاستفسار غير موجود.");
                }

                var inquiry = _mapper.Map<Inquiry>(inquiryDto);
                inquiry.Id = Id;
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

        public IEnumerable<InquiryDto> GetInquiriesByDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("تاريخ البدء يجب أن يكون قبل تاريخ الانتهاء.");
            }

            try
            {
                var inquiries = _unitOfWork.Inquiry.GetAll()
                    .Where(i => i.DateSent >= startDate && i.DateSent <= endDate)
                    .ToList();
                return _mapper.Map<IEnumerable<InquiryDto>>(inquiries);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("حدث خطأ أثناء جلب الاستفسارات بناءً على النطاق الزمني.", ex);
            }
        }


        private void ValidateInquiryDto(InquiryDto inquiryDto)
        {
            if (inquiryDto == null)
                throw new ArgumentNullException(nameof(inquiryDto));

            if (string.IsNullOrEmpty(inquiryDto.Message))
                throw new ArgumentException("Property title is required.", nameof(inquiryDto.Message));

        }

    }
}
