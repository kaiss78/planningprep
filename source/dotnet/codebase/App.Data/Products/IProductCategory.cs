using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models.Products;

namespace App.Data.Products
{
    public interface IProductCategoryDAO : IDataAccess<ProductCategory>
    {
    }
}
