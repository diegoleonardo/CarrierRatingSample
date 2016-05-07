using System.Web.Mvc;
using CarrierRating.WebApplication.Models;
using AspNet.Identity.MongoDB;
using CarrierRating.WebApplication.App_Start;
using Microsoft.AspNet.Identity;
using CarrierRating.Domain.Entities;

namespace CarrierRating.WebApplication.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected User UserBase { get; private set; }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            var context = ApplicationIdentityContext.Create();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context.Users));
            var usuario = userManager.FindByName(requestContext.HttpContext.User.Identity.Name);
            if (usuario != null)
                UserBase = usuario.UserInfo;
            base.Initialize(requestContext);
        }
    }
}