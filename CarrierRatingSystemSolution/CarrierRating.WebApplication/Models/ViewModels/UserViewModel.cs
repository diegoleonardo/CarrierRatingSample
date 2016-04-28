using CarrierRating.Domain.DTO;

namespace CarrierRating.WebApplication.Models.ViewModels
{
    public class UserViewModel
    {
        public UserDTO UserDTO { get; set; }
        public UserViewModel() {}
        public UserViewModel(UserDTO userDTO){
            UserDTO = userDTO;
        }
    }
}