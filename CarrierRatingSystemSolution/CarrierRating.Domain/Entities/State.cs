namespace CarrierRating.Domain.Entities
{
    public class State: GeographicCoordinate
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
    }
}