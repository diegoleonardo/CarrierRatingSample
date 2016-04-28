using AspNet.Identity.MongoDB;
using CarrierRating.Domain.Entities;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarrierRating.WebApplication.Models
{
    public class ApplicationUser: IdentityUser
    {
        public virtual User UserInfo { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
