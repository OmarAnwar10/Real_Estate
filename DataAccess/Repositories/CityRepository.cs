using _DataAccess.Contracts;
using _DataAccess.Models;
using API_Project.DataAccess.Repositories;
using application.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DataAccess.Repositories
{
    internal class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {
        }
        public City? GetCityByName(string name)
        {
            return _dbSet.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
