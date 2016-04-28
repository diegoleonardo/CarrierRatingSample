using CarrierRating.Domain.DTO;
using CarrierRating.Domain.Entities;
using System.Collections.Generic;

namespace CarrierRating.WebApplication.Models.ViewModels
{
    public class RatingViewModel
    {
        public string Id { get; set; }
        public EnumRate Rate { get; set; }
        public string Description { get; set; }
        public string CarrierId { get; set; }
        public string CarrierName { get; set; }
        public CarrierDTO CarrierRate { get; set; }
        public UserDTO User;
        public IList<CarrierDTO> CarriersToRating;
        public IList<RatingDTO> Ratings;

        public RatingViewModel()
        {
            CarriersToRating = new List<CarrierDTO>();
            Ratings = new List<RatingDTO>();
        }

        public void SetCarriersToRatingList(IList<Carrier> carriers)
        {
            foreach (var carrier in carriers)
            {
                this.CarriersToRating.Add(carrier.GetDTO());
            }
        }

        public void SetRatingsList(IList<Rating> ratings)
        {
            foreach (var rating in ratings)
            {
                this.Ratings.Add(rating.GetDTO());
            }
        }

        public void MapperRatingDTO(RatingDTO rating)
        {
            this.Id = rating.Id.ToString();
            this.Rate = rating.Rate;
            this.User = rating.User.GetDTO();
            this.CarrierRate = rating.Carrier.GetDTO();
        }
    }
}