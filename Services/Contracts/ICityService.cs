using _DataAccess.Models;
using _Services.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Services.Contracts
{
    public interface ICityService
    {
        IEnumerable<City_Get> GetCities();
        City_Get GetCityById(int id);
        City_Get GetCityByName(string cityName);
        void CreateCity(City_Add _city);
        void UpdateCity(int Id, City_Update _city);
        void DeleteCity(int id);
    }
}
