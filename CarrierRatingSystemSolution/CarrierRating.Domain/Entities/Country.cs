namespace CarrierRating.Domain.Entities
{
    public class Country: GeographicCoordinate
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}