﻿using _Services.Models.Amenities;
using _Services.Models.PropertyImage;
using application.DataAccess.Models;

namespace _Services.Models.Property
{
    public class Property_Create
    {
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public double Area { get; set; }
        public PropType PropertyType { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int? YearBuilt { get; set; }
        public Status Status { get; set; }

        public Amenities_Create Amenities { get; set; }
        public IEnumerable<PropertyImage_Create> Images { get; set; }

    }
}
