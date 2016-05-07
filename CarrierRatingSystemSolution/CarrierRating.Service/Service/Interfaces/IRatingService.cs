using CarrierRating.Domain.Entities;
using CarrierRating.Service.Service.Base;
using System.Collections.Generic;

namespace CarrierRating.Service.Service.Interfaces
{
    public interface IRatingService: IEntityServiceBase<Rating>
    {
        Carrier GetCarrierById(string id);
        IList<Rating> GetRatingByUserId(string userId);
        IList<Carrier> GetCarrierToRating(string userId);
    }
}
