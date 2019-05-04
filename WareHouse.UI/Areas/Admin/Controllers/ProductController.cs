using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouse.Model.Entity;
using WareHouse.UI.Areas.Admin.Models.DTO;

namespace WareHouse.UI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {

        public ActionResult AddProduct()
        {
            List<Category> model = db.Categories.Where(x => x.Status == Model.Enum.Status.Active || x.Status == Model.Enum.Status.Updated).OrderBy(x => x.AddDate).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddProduct(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                product.ProductName = model.ProductName;
                product.ProductDescription = model.ProductDescription;
                product.UnitPrice = model.UnitPrice;
                product.UnitsInStock = model.UnitsInStock;
                product.CategoryID = model.CategoryID;
                db.Products.Add(product);
                db.SaveChanges();
                return Redirect("/Admin/Product/ProdcutList");
            }
            else
            {
                return View();
            }
        }
        public ActionResult ProdcutList()
        {
            List<ProductDTO> model = db.Products.Where(x => x.Status == Model.Enum.Status.Active || x.Status == WareHouse.Model.Enum.Status.Updated).OrderBy(x => x.CategoryID).Select(x => new ProductDTO
            {
                ID = x.ID,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,              
                UnitsInStock = x.UnitsInStock,
                UnitPrice = x.UnitPrice,
                CategoryID = x.CategoryID,
                CategoryName = x.Category.CategoryName,          
            }).ToList();

            return View(model);
        }
    }
    
}