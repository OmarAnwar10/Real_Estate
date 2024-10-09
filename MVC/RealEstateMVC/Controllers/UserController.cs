using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace RealEstateMVC.Controllers
{
    public class UserController : Controller
    {
        //private readonly IUserService _UserService;
        //public UserController(/*IUserService userService*/)
        //{
        //    _userService = new UserService();
        //}
        public IActionResult Index(int? val)
        {
            ViewData["Val"] = val ?? 0; // Pass the value to the view, default to 0 if val is not provided
            return View();
        }
        public ActionResult Profile()
        {
            return PartialView("./Partials/AccountInfo");
        }

        public ActionResult Property()
        {
            return PartialView("./Partials/PropertyInfo");
        }
        public ActionResult Favorite()
        {
            return PartialView("./Partials/FavoriteProperty");
        }

        public ActionResult Messages()
        {
            return PartialView("./Partials/Messages");
        }
        public ActionResult SubmitProperty()
        {
            return PartialView("./Partials/SubmitProperty");
        }
        public ActionResult ChangePassword()
        {
            return PartialView("./Partials/ChangePassword");
        }
    }
}
