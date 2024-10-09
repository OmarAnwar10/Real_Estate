using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstateMVC.Models
{
    public class PropertyViewModel
    {
        public int PropertyId { get; set; }
        [StringLength(50)]
        public string PropertyName { get; set; }
        public string UserFullName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PropertyPrice { get; set; }
        public string PropertyAddress { get; set; }
        public string PropertyCityName { get; set; }
        public double AreaInMeters { get; set; }
        public string PropertyTypeName { get; set; } // نوع العقار (شقة، فيلا، مكتب، إلخ)
        [Required]
        public int BedroomsNumber { get; set; }
        [Required]
        public int BathroomsNumber { get; set; }

        public DateTime PropertyDateAdded { get; set; }
        public int YearBuilt { get; set; }
        [Required]
        public string PropertyStatusName { get; set; } // حالة العقار (متاح، مباع، تحت التفاوض)       
        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }
        public string AdditionalNotes { get; set; }

        public IEnumerable<string> PropertyImagePaths { get; set; }

        public bool HasGarage { get; set; }
        public bool Two_Stories { get; set; }
        public bool Laundry_Room { get; set; }
        public bool HasPool { get; set; }
        public bool HasGarden { get; set; }
        public bool HasElevator { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasParking { get; set; }
        public bool HasCentralHeating { get; set; }
        public bool IsFurnished { get; set; }
    }
}
