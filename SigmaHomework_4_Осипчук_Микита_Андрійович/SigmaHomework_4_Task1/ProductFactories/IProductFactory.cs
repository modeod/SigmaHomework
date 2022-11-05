using SigmaHomework_4_Task1.ProductsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_4_Task1.ProductFactories
{
    public interface IProductFactory
    {
        ProductModel Create();
    }
}
