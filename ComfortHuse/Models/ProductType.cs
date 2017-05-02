namespace Comforthuse.Models
{
    public enum ProductCategory
    {
        HouseType,
        CarportGarage,
        Plot,
        MaterialOutside,
        WindowsDoors,
        MaterialInside,
        Interior,
        Flooring,
        Power,
        Appliances,
        Tiles,
        Carpentry,
        Painting,
        Plumbing,
        Ventilation,
        BuildOn,
        Other
    }
    public class ProductType
    {
        public ProductCategory Category { get; set; }


    }

    /*
      public interface IExpenseCategory
      {
          string Title { get; }
          string Price { get; }

      }

      }

      class 

      class PresetExpenseSpecification : ExpenseSpecification
      {
          private int Amount { get; set; }
          private double PricePerUnit { get; set; }
      }
      */

}




