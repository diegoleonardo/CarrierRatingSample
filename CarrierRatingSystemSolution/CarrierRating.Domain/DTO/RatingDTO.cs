
using CarrierRating.Domain.Entities;
using MongoDB.Bson;

namespace CarrierRating.Domain.DTO
{
    public class RatingDTO: Rating
    {
        public RatingDTO(Rating rating)
        {
            this.Id = rating.Id;
            this.Rate = rating.Rate;
            this.Description = rating.Description;
            this.User = rating.User;
            this.Carrier = rating.Carrier;
        }

        public RatingDTO(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                this.Id = new ObjectId();
            else
                this.Id = new ObjectId(id);
        }
    }
}
