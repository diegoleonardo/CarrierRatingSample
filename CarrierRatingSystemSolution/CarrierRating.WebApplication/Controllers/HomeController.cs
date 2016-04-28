using CarrierRating.Service.Service.Interfaces;
using CarrierRating.WebApplication.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace CarrierRating.WebApplication.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(IUserService userService)
        {
        }

        public ActionResult Index()
        {
            var userViewModel = new UserViewModel();
            return View(userViewModel);
        }
    }
}