using CarrierRating.Data.Base;
using CarrierRating.Data.Repository.Interfaces;
using CarrierRating.Domain.Entities;

namespace CarrierRating.Data.Repository.Repositories
{
    public class CarrierRepository: EntityRepositoryBase<Carrier>, ICarrierRepository
    {
    }
}
