using Microsoft.AspNetCore.Mvc;
using RealEstateMVC.Models;
using Service.Service;
using System.Diagnostics;

namespace RealEstateMVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IHomeService _HomeService;
        //public HomeController(/*IHomeService HomeService*/)
        //{
        //    _HomeService = new HomeService();
        //}
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
