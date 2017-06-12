using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comforthuse.Models;

namespace Comforthuse.Interfaces
{
    public interface IEmployeeFacade
    {
        ICase CreateCase();
        void GetAllProductOptions();
        List<IProductType> LoadProductType(Category category);
        List<ICase> GetAllCases();
        List<IEmployee> GetAllEmployees();
        void GetAllProductTypes();
    }
}
