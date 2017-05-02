namespace Comforthuse.Models
{
    public class HouseType
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public string Bet { get; set; }
        public int WallMaterial { get; set; }
        public float PricePerSqM { get; set; }
        public float MoneySetAsideForInterior { get; set; }
        public double UnitPriceSkeletonFyn { get; set; }
        public double UnitPriceSkeletonSjaelland { get; set; }
        public double SkeletonPriceFyn => UnitPriceSkeletonFyn * Area;
        public double PriceSjaelland => UnitPriceSkeletonFyn * Area;
        public double TotalPriceFyn => PricePerSqM * Area;
        public double TotalPriceSjaelland => PricePerSqM * Area * 1.175;
        public double SelectionPriceTotal => PricePerSqM * Area * 1.175;
    }
}
