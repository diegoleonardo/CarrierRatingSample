
using CarrierRating.Domain.Entities.MongoEntities;

namespace CarrierRating.Domain.Entities.Base
{
    public class Company: MongoEntity
    {
        public string EIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string GetFullName()
        {
            return FirstName.Trim() + " " + LastName.Trim();
        }
    }
}
