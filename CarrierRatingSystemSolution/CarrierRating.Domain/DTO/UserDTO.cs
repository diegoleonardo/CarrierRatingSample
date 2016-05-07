using CarrierRating.Domain.Entities;

namespace CarrierRating.Domain.DTO
{
    public class UserDTO: User
    {
        public UserDTO() { }
        public UserDTO(User pUser)
        {
            this.Id = pUser.Id;
            this.FirstName = pUser.FirstName;
            this.LastName = pUser.LastName;
            this.Birthdate = pUser.Birthdate;
        }

        public string GetId()
        {
            return this.Id.ToString();
        }
    }
}
