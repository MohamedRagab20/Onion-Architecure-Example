using OA.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service
{
   public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(long id);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(long id);
    }
}
