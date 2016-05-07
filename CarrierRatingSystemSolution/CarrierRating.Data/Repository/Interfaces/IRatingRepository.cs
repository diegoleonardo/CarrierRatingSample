using CarrierRating.Data.Base;
using CarrierRating.Domain.Entities;
using System.Collections.Generic;

namespace CarrierRating.Data.Repository.Interfaces
{
    public interface IRatingRepository: IEntityRepositoryBase<Rating>
    {
        Rating GetByUserId(string userId);
        IList<Rating> GetByCarrierId(string carrierId);
    }
}
