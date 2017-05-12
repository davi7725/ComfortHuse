namespace Comforthuse.Models
{
    //To be removed
    public class HouseType
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public int WallMaterial { get; set; }
        public decimal PricePerSqM { get; set; }
        public float MoneySetAsideForInterior { get; set; }
        public decimal UnitPriceSkeletonFyn { get; set; }
        public decimal UnitPriceSkeletonSjaelland { get; set; }
        public decimal SkeletonPriceFyn => UnitPriceSkeletonFyn * Area;
        public decimal PriceSjaelland => UnitPriceSkeletonFyn * Area;
        public decimal TotalPriceFyn => PricePerSqM * Area;
        public decimal TotalPriceSjaelland => PricePerSqM * Area * 1.175m;
        public decimal SelectionPriceTotal => PricePerSqM * Area * 1.175m;
    }
}
