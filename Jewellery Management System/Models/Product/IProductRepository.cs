using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Models
{
    public interface IProductRepository
    {
        Product Add(Product product);
        Product GetProduct(int? ProductID);
        IEnumerable<Product> GetProducts();
        Product Edit(Product product);
        Product Delete(int id);
    }
}
