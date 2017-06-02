﻿namespace Comforthuse.Interfaces
{
    public interface IProductOption
    {
        int ProductId { get; set; }
        string Name { get; set; }
        decimal PriceFyn { get; set; }
        decimal PriceSjaelland { get; set; }
        string UnitType { get; set; }
        bool Standard { get; set; }
    }
}
