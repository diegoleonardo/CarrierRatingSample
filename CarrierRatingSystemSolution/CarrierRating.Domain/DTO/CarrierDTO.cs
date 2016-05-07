using CarrierRating.Domain.Entities;
using MongoDB.Bson;

namespace CarrierRating.Domain.DTO
{
    public class CarrierDTO: Carrier
    {
        public CarrierDTO() { }
        public CarrierDTO(string id) {
            if (string.IsNullOrWhiteSpace(id))
                this.Id = new ObjectId();
            else
                this.Id = new ObjectId(id);
        }

        public CarrierDTO(Carrier carrier)
        {
            this.Id = carrier.Id;
            this.EIN = carrier.EIN;
            this.FirstName = carrier.FirstName;
            this.LastName = carrier.LastName;
            this.Address = carrier.Address;
            this.Ratings = carrier.Ratings;
        }
    }
}
