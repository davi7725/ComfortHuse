﻿using Comforthuse.Interfaces;
using System.Collections.Generic;

namespace Comforthuse.Models
{
    public interface IProductType
    {
        int ProductTypeId { get; set; }
        Category Category { get; set; }
        string Name { get; set; }
        List<IProductOption> ListOfProductOptions { get; }
    }
}