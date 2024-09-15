using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public enum Status : byte
    {
        rent = 1,
        buy = 2,
        used = 4
    }

    public class Property
    {

        public int Id { get; set; } // الرقم التعريفي للعقار (Primary Key)
        [StringLength(20)]
        public string Name { get; set; } // renamed from Name

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // سعر العقار
        public string Address { get; set; } // renamed from Address
        public string City { get; set; }
        public double AreaInMeters { get; set; } // renamed from AreaInMeters
        public string PropertyType { get; set; } // نوع العقار (شقة، فيلا، مكتب، إلخ)
        [Required]
        public int BedroomsNumber { get; set; } // renamed from BedroomsNumber
        [Required]
        public int BathroomsNumber { get; set; }// renamed from BathroomsNumber

        public DateTime DateAdded { get; set; } // تاريخ إضافة العقار
        public int YearBuilt { get; set; } // سنة بناء العقار
        [Required]
        public Status Status { get; set; } // حالة العقار (متاح، مباع، تحت التفاوض)
        public int AmenitiesId { get; set; }
        public int UserId { get; set; } // renamed from UserId
        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; } // وصف العقار  
        public string AdditionalNotes { get; set; } // ملاحظات إضافية حول العقار
        public User User { get; set; } // renamed from User
        public IEnumerable<PropertyImage> PropertyImages { get; set; } //changed from list to class
        public IEnumerable<Inquiry> Inquiries { get; set; } // الاستفسارات المتعلقة بالعقار
        public IEnumerable<Favorite> Favorites { get; set; }
        public virtual Amenities Amenities { get; set; }
    }
}
