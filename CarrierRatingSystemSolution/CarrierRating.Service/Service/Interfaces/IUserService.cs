using CarrierRating.Domain.DTO;
using CarrierRating.Domain.Entities;
using CarrierRating.Service.Service.Base;

namespace CarrierRating.Service.Service.Interfaces
{
    public interface IUserService: IEntityServiceBase<User>
    {
        UserDTO GetByEmail(UserDTO pUser);
        bool isUserOfSystem(UserDTO pUser);
    }
}
