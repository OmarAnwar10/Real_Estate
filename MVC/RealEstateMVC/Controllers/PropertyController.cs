using Microsoft.AspNetCore.Mvc;
using RealEstateMVC.Services.Contracts;
using Service.Service;

namespace RealEstateMVC.Controllers
{
    public class PropertyController : Controller
    {
        private readonly PropertyService _propertyService;
        public PropertyController(/*IPropertyService propertyService*/) 
        {
            _propertyService = new PropertyService();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditProperty()
        {
            return View();
        }
        public IActionResult PropertyDetails()
        {
            return View();
        }
        public IActionResult PropertyMessages()
        {
            return View();
        }
        public async Task<IActionResult> GetProperty()
        {
            return View(await _propertyService.GetAllPropertiesAsync());
        }
    }
}
