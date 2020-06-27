using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OA.Data.Models;
using OA.Service;
using OA.Web.ViewModels;

namespace OA.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productSevice;

        public ProductController(IProductService productSevice)
        {
            this.productSevice = productSevice;
        }
        public IActionResult Index()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();

            products =
                productSevice.GetProducts().ToList().Select(u => new ProductViewModel
                { Id = u.Id, name = u.NameAr, name_en = u.NameEn }).ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult RenderProductModal(int id)
        {
            ProductViewModel p = new ProductViewModel();

            if (id > 0)
            {
                Product pro = productSevice.GetProduct(id);

                if (pro.Id > 0)
                {
                    p.Id = pro.Id;
                    p.name = pro.NameAr;
                    p.name_en = pro.NameEn;
                }
            }

            return PartialView("_Product", p);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel product)
        {
            if (product.Id <= 0)
            {
                productSevice.InsertProduct(new Product()
                {
                    Id = product.Id,
                    NameAr = product.name,
                    NameEn = product.name_en
                });
            }
            else
            {
                Product pro = productSevice.GetProduct(product.Id);

                pro.NameAr = product.name;
                pro.NameEn = product.name_en;

                productSevice.UpdateProduct(pro);
            }
            return RedirectToAction("Index");
        }
    }
}