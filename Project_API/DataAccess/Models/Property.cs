using API_Project.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace application.DataAccess.Models
{

  public enum Status : byte
  {
    rent = 1,
    boy = 2,
    used = 4
  }

  public class Property
  {

    public int Id { get; set; } // الرقم التعريفي للعقار (Primary Key)
    [StringLength(20)]
    public string Title { get; set; } // عنوان العقار

    [Column(TypeName = "nvarchar(MAX)")]
    public string Description { get; set; } // وصف العقار   

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; } // سعر العقار
    public string Location { get; set; } // موقع العقار
    public string City { get; set; }
    public double Area { get; set; } // مساحة العقار بالمتر المربع
    public string PropertyType { get; set; } // نوع العقار (شقة، فيلا، مكتب، إلخ)
    [Required]
    public int Bedrooms { get; set; } // عدد غرف النوم
    [Required]
    public int Bathrooms { get; set; } // عدد الحمامات
    public IList<string> Images { get; set; } // روابط صور العقار
    public DateTime DateAdded { get; set; } // تاريخ إضافة العقار
    public int YearBuilt { get; set; } // سنة بناء العقار
    [Required]
    public Status Status { get; set; } // حالة العقار (متاح، مباع، تحت التفاوض)
    public int? AmenitiesId { get; set; }
    public int? OwnerId { get; set; } // الرقم التعريفي لصاحب العقار (ممكن يكون null لو العقار مش متاح للبيع)
    public virtual User Owner { get; set; } // صاحب العقار

    public IList<Inquiry> Inquiries { get; set; } // الاستفسارات المتعلقة بالعقار
    public virtual Amenities Amenities { get; set; }

  }

  public class Amenities
  {
    public int Id { get; set; }
    public bool HasGarage { get; set; } // إذا كان العقار يحتوي على جراج
    public bool Two_Stories { get; set; }
    public bool Laundry_Room { get; set; }
    public bool HasPool { get; set; } // إذا كان العقار يحتوي على حمام سباحة
    public bool HasGarden { get; set; } // إذا كان العقار يحتوي على حديقة
    public bool HasElevator { get; set; } // إذا كان العقار يحتوي على مصعد
    public bool HasBalcony { get; set; } // إذا كان العقار يحتوي على بلكونة
    public bool HasParking { get; set; } // إذا كان العقار يحتوي على مواقف سيارات
    public bool HasCentralHeating { get; set; } // إذا كان العقار يحتوي على تدفئة مركزية
    public bool IsFurnished { get; set; } // إذا كان العقار مفروشًا
    public string AdditionalNotes { get; set; } // ملاحظات إضافية حول العقار
  }

}
