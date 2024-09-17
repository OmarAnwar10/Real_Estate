using _DataAccess.Models;
using API_Project.DataAccess.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace application.DataAccess.Models
{

    public enum Status : byte
    {
        rent = 1,
        buy = 2,
        used = 4
    }

    public enum PropType : byte
    {
        apartment = 1,
        villa = 2,
        office = 3,
        land = 4,
        shop = 5,
        warehouse = 6,
        building = 7,
        other = 8
    }

    public class Property
    {
        public int Id { get; set; } // الرقم التعريفي للعقار (Primary Key)
        [StringLength(20)]
        public string Title { get; set; } // عنوان العقار

        [Column(TypeName = "nvarchar(MAX)")]
        public string? Description { get; set; } // وصف العقار   

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // سعر العقار
        public string Location { get; set; } // موقع العقار
        public double Area { get; set; } // مساحة العقار بالمتر المربع
        public PropType PropertyType { get; set; } // نوع العقار (شقة، فيلا، مكتب، إلخ)
        [Required]
        public int Bedrooms { get; set; } // عدد غرف النوم
        [Required]
        public int Bathrooms { get; set; } // عدد الحمامات
        public DateTime DateAdded { get; set; } // تاريخ إضافة العقار
        public int? YearBuilt { get; set; } // سنة بناء العقار
        [Required]
        public Status Status { get; set; } // حالة العقار (متاح، مباع، تحت التفاوض)


        public int OwnerId { get; set; } // الرقم التعريفي لصاحب العقار (ممكن يكون null لو العقار مش متاح للبيع)
        public virtual User Owner { get; set; } // صاحب العقار

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public int AmenitiesId { get; set; }
        public virtual Amenities Amenities { get; set; }


        public virtual IEnumerable<PropertyImage> Images { get; set; } // روابط صور العقار
        public virtual IEnumerable<Inquiry> Inquiries { get; set; } // الاستفسارات المتعلقة بالعقار


    }


}
