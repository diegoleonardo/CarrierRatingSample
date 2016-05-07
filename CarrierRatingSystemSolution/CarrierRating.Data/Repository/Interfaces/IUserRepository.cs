using CarrierRating.Data.Base;
using CarrierRating.Domain.Entities;

namespace CarrierRating.Data.Repository.Interfaces
{
    public interface IUserRepository: IEntityRepositoryBase<User>
    {
        User GetByEmail(User pUser);
        bool IsUserOfSystem(User pUser);
    }
}
