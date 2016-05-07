using CarrierRating.Domain.DTO;
using CarrierRating.Domain.Entities.Base;
using CarrierRating.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CarrierRating.Domain.Entities
{
    public class Carrier: Company, IDataTransferObject<CarrierDTO>
    {
        public IList<Rating> Ratings { get; set; }
        public Carrier()
        {
            this.Ratings = new List<Rating>();
        }

        public int GetAverageRate()
        {
            var average = 0;
            var count = this.Ratings.Count;
            var sumRate = this.Ratings.Sum(x => (int)x.Rate);
            if(sumRate > 0 && count > 0)
                average = sumRate / count;
            return average;
        }

        public CarrierDTO GetDTO()
        {
            var carrierDTO = new CarrierDTO(this);
            return carrierDTO;
        }
    }
}
