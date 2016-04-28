
namespace CarrierRating.Service
{
    public interface IServiceLocator
    {
        T GetService<T>();
    }
}
