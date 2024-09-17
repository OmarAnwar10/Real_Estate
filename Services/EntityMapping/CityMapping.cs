using _DataAccess.Models;
using _Services.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Services.EntityMapping
{
    public class CityMapping
    {
        public static City MapCityAddToCity(City_Add city)
        {
            return new City
            {
                Name = city.Name
            };
        }

        public static City MapCityUpdateToCity(City_Update city)
        {
            return new City
            {
                Name = city.Name
            };
        }

        public static City_Get MapCityToCityGet(City city)
        {
            return new City_Get
            {
                Id = city.Id,
                Name = city.Name
            };
        }
    }
}
