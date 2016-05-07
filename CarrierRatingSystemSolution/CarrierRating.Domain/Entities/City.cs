namespace CarrierRating.Domain.Entities
{
    public class City: GeographicCoordinate
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
    }
}