using CarrierRating.Domain.DTO;
using CarrierRating.Service.Service.Interfaces;
using System;
using System.Web.Mvc;

namespace CarrierRating.WebApplication.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _userService;
        public UserController(IUserService pUserService)
        {
            _userService = pUserService;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserDTO pUser)
        {
            try
            {
                _userService.Create(pUser);
            }
            catch (Exception e)
            {

            }
            return View();
        }
    }
}