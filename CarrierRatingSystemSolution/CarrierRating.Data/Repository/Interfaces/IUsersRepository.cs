using CarrierRating.Domain.Entities;

namespace CarrierRating.Data.Repository.Interfaces
{
    public interface IUsersRepository
    {
        User GetByEmail(string email);
    }
}
