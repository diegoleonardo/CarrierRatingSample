
namespace CarrierRating.Data.ServiceLocator
{
    public interface IRepositoryServiceLocator
    {
        T GetRepositoryService<T>();
    }
}
