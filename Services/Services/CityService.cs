using _DataAccess.Models;
using _Services.Contracts;
using _Services.EntityMapping;
using _Services.Models.City;
using Application.DataAccessContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Services.Services
{
    internal class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<City_Get> GetCities()
        {
            try
            {
                return _unitOfWork.City.GetAll().Select(c => CityMapping.MapCityToCityGet(c));
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while getting cities.", ex);
            }
        }

        public City_Get GetCityById(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Invalid Id");

                City? city = _unitOfWork.City.GetById(id);
                if (city == null)
                {
                    throw new Exception("City not found");
                }
                return CityMapping.MapCityToCityGet(city);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while getting city by id.", ex);
            }
        }

        public City_Get GetCityByName(string name) {
            try
            {
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Invalid Name");

                City? city = _unitOfWork.City.GetCityByName(name);
                if (city == null)
                {
                    throw new Exception("City not found");
                }
                return CityMapping.MapCityToCityGet(city);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while getting city by name.", ex);
            }
        }

        public void CreateCity(City_Add _city)
        {
            try
            {
                if (_unitOfWork.City.GetCityByName(_city.Name) != null)
                    throw new Exception("City already exists");

                if (string.IsNullOrEmpty(_city.Name))
                    throw new Exception("Invalid Name");
                City city = CityMapping.MapCityAddToCity(_city);
                _unitOfWork.City.Insert(city);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while creating city.", ex);
            }
            
        }
        
        public void DeleteCity(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Invalid Id");

                City? city = _unitOfWork.City.GetById(id);
                if (city == null)
                {
                    throw new Exception("City not found");
                }
                _unitOfWork.City.Delete(city.Id);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while deleting city.", ex);
            }
            
        }

        public void UpdateCity(int Id, City_Update _city)
        {
            try
            {
                City? city = _unitOfWork.City.GetById(Id);
                if (city == null)
                {
                    throw new Exception("City not found");
                }
                city.Name = _city.Name;
                _unitOfWork.City.Update(city);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating city.", ex);
            }

        }

        
    }
}
