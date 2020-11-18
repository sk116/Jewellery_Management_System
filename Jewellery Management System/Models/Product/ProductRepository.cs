using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jewellery_Management_System.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly ContextClass context;
        public ProductRepository(ContextClass context)
        {
            this.context = context;
        }

        Product IProductRepository.Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        Product IProductRepository.GetProduct(int? ProductID)
        {
            return context.Products.Find(ProductID);
        }

        IEnumerable<Product> IProductRepository.GetProducts()
        {
            return context.Products;
        }
        Product IProductRepository.Edit(Product product)
        {
            var pd = context.Products.Attach(product);
            pd.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return product;
        }
        Product IProductRepository.Delete(int id)
        {
            Product product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return product;
        }
    }
}
