using CarrierRating.Domain.Entities.Base;
using CarrierRating.Domain.DTO;
using CarrierRating.Domain.Interfaces;

namespace CarrierRating.Domain.Entities
{
    public class User: Person, IDataTransferObject<UserDTO>
    {
        public string Email { get; set; }

        public override string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public UserDTO GetDTO()
        {
            return new UserDTO(this);
        }
    }
}
