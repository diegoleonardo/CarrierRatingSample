namespace CarrierRating.Domain.Entities
{
    public class Address: GeographicCoordinate
    {
        public int AddressId { get; set; }
        public string FullName { get; set; }
        public string StreetAddress { get; set; }
        public City City { get; set; }
        public string ZipCode { get; set; }
    }
}