using CarrierRating.Domain.DTO;
using CarrierRating.Domain.Entities;
using System.Collections.Generic;

namespace CarrierRating.WebApplication.Models.ViewModels
{
    public class CarrierViewModel
    {
        public string Id { get; set; }
        public string EIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public IList<CarrierDTO> Carriers { get; }

        public CarrierViewModel()
        {
            this.Id = string.Empty;
            this.EIN = string.Empty;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Address = new Address();
            this.Carriers = new List<CarrierDTO>();
        }

        public void SetCarriersList(IList<Carrier> carriers)
        {
            foreach(var carrier in carriers)
            {
                this.Carriers.Add(carrier.GetDTO());
            }
        }

        public void MapperCarrierDTO(CarrierDTO carrierDTO)
        {
            this.Id = carrierDTO.Id.ToString();
            this.EIN = carrierDTO.EIN;
            this.FirstName = carrierDTO.FirstName;
            this.LastName = carrierDTO.LastName;
            this.Address = carrierDTO.Address;
        }

    }
}