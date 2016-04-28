using CarrierRating.Data.Base;
using CarrierRating.Domain.Entities;

namespace CarrierRating.Data.Repository.Interfaces
{
    public interface ILoginRepository: IEntityRepositoryBase<Login>
    {
        bool HasLogin(Login pLogin);
    }
}
