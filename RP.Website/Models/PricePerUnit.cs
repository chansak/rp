namespace RP.Website.Models
{
    public class PricePerUnit
    {
        public string Id { get; set; }
        public UnitTypeViewModel UnitTypeViewModel { get; set; }
        public decimal Price { get; set; }
    }
}