using application.DataAccess.Models;

namespace API_Project.DataAccess.DTOs
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public double Area { get; set; }
        public string PropertyType { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public DateTime DateAdded { get; set; }
        public int YearBuilt { get; set; }
        public Status Status { get; set; }
        public AmenitiesDto Amenities { get; set; }
        public int UserId { get; set; }

        //public UserDto Owner { get; set; }
        public List<string> Images { get; set; }
    }
    public class AmenitiesDto
    {
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
        public string AdditionalNotes { get; set; }
    }

}
