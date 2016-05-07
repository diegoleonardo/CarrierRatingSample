using CarrierRating.Service.Service.Interfaces;
using CarrierRating.WebApplication.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CarrierRating.WebApplication.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private SignInHelper _helper;

        private SignInHelper SignInHelper
        {
            get
            {
                if (_helper == null)
                {
                    _helper = new SignInHelper(UserManager, AuthenticationManager);
                }
                return _helper;
            }
        }
        public AccountController(IUserService pUserService)
        {
            _userService = pUserService;
        }
        public AccountController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await SignInHelper.PasswordSignIn(model.UserDTO.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case Models.SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userService.Create(model.UserDTO);
                    var user = new ApplicationUser { UserName = model.UserDTO.Email, Email = model.UserDTO.Email, UserInfo = model.UserDTO };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    TempData["AlertSuccessCreateUser"] = "Operation Done!";
                }
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("CustomErrorCreateUser", e.Message);
            }
            return View();
        }

        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account", new { returnUrl = "" });
        }
    }
}