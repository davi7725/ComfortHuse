namespace Comforthuse.Models
{
    public class HouseType : IHouseType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Area { get; set; }
        public decimal? UnitPrice {
            get {
                return TotalPrice/Area;
            }
        }
        public decimal? TotalPrice { get; set; }
    }

    public interface IHouseType
    {
        string Name { get; set; }
        string Description { get; set; }
        int? Area { get; set; }
        decimal? UnitPrice { get; }
        decimal? TotalPrice { get; set; }
    }
}
