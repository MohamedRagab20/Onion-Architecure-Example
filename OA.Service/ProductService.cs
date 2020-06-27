using OA.Data.Models;
using OA.Repo;
using System;
using System.Collections.Generic;

namespace OA.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepo;

        public ProductService(IRepository<Product> productRepo)
        {
            this.productRepo = productRepo;
        }

        public void DeleteProduct(long id)
        {
            Product product = productRepo.Get(id);
            productRepo.Remove(product);
            productRepo.SaveChanges();
        }

        public Product GetProduct(long id)
        {
            return productRepo.Get(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return productRepo.GetAll();
        }

        public void InsertProduct(Product product)
        {
            productRepo.Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            productRepo.Update(product);
        }
    }
}
