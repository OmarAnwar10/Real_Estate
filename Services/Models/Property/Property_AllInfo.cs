﻿using _Services.Models.Amenities;
using _Services.Models.User;
using application.DataAccess.Models;

namespace _Services.Models.Property
{
    public class Property_AllInfo
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public User_Basic Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public double Area { get; set; }
        public string PropertyType { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int? YearBuilt { get; set; }
        public DateTime DateAdded { get; set; }
        public Status Status { get; set; }
        public Amenities_Out Amenities { get; set; }
        public IEnumerable<String> Image { get; set; }

    }
}
