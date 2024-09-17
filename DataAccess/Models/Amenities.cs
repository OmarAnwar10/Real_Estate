using application.DataAccess.Models;

namespace _DataAccess.Models
{
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

        public virtual IEnumerable<Property> Properties { get; set; }
    }
}
