using CarrierRating.Domain.Entities.MongoEntities;

namespace CarrierRating.Domain.Interfaces
{
    public interface IDataTransferObject<T>where T : MongoEntity
    {
        T GetDTO();
    }
}
