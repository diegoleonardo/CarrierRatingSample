using CarrierRating.Domain.DTO;

namespace CarrierRating.WebApplication.Models
{
    public class LoginViewModel
    {
        public UserDTO UserDTO { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public LoginViewModel()
        {
            this.UserDTO = new UserDTO();
        }
    }
}
