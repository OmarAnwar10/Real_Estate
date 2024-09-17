using _DataAccess.Models;
using API_Project.DataAccess.Models;
using Application.DataAccessContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccess.Contracts
{
    public interface ICityRepository : IBaseRepository<City>
    {
        City? GetCityByName(string name);
    }
}
