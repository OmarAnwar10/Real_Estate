using RealEstateMVC.Models;

namespace RealEstateMVC.Services.Contracts
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyViewModel>> GetAllPropertiesAsync();
    }
}
