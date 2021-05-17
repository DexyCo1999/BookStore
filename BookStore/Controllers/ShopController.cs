using BookStore.Models.Data;
using BookStore.Models.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
 public class ShopController : Controller
 {
    // GET: Shop
    public ActionResult Index()
    {
        return RedirectToAction("Index", "Pages");
    }
    
    public ActionResult CategoryMenuPartial()
    {
        // Declare list 
        List<CategoryVM> categoryVMList;

        // Init the list
        using (Db db = new Db())
        {
            categoryVMList = db.Categories.ToArray().OrderBy(x => x.Sorting).Select(x => new CategoryVM(x)).ToList();
        }

        // Return partial with list
        return PartialView(categoryVMList);
    }
    public ActionResult AuthorMenuPartial()
     {
         // Declare list 
         List<AuthorVM> authorVMList;

                // Init the list
         using (Db db = new Db())
         {
                authorVMList = db.Authors.ToArray().OrderBy(x => x.Sorting).Select(x => new AuthorVM(x)).ToList();
         }

         // Return partial with list
         return PartialView(authorVMList);
    }
        public ActionResult PubHouseMenuPartial()
        {
            // Declare list 
            List<PubHouseVM> pubHouseVMList;

            // Init the list
            using (Db db = new Db())
            {
                pubHouseVMList = db.PubHouses.ToArray().OrderBy(x => x.Sorting).Select(x => new PubHouseVM(x)).ToList();
            }

            // Return partial with list
            return PartialView(pubHouseVMList);
        }


        
            // GET: /shop/category/name
            public ActionResult Category(string name)
            {
                // Declare a list of ProductVM
                List<ProductVM> productVMList;

                using (Db db = new Db())
                {
                    // Get category id
                    CategoryDTO categoryDTO = db.Categories.Where(x => x.Slug == name).FirstOrDefault();
                    int catId = categoryDTO.Id;


                    // Init the list
                    productVMList = db.Products.ToArray().Where(x => x.CategoryId == catId).Select(x => new ProductVM(x)).ToList();

                    // Get category name
                    var productCat = db.Products.Where(x => x.CategoryId == catId).FirstOrDefault();
                    ViewBag.CategoryName = productCat.CategoryName;
                }

                // Return view with list
                return View(productVMList);
            }
        
        public ActionResult Author(string name)
        {
            // Declare a list of ProductVM
            List<ProductVM> productVMList;

            using (Db db = new Db())
            {
                // Get category id
                AuthorDTO authorDTO = db.Authors.Where(x => x.Slug == name).FirstOrDefault();
                int autId = authorDTO.Id;


                // Init the list
                productVMList = db.Products.ToArray().Where(x => x.AuthorId == autId).Select(x => new ProductVM(x)).ToList();

                // Get category name
                var productAut = db.Products.Where(x => x.AuthorId == autId).FirstOrDefault();
                ViewBag.AuthorName = productAut.AuthorName;
            }

            // Return view with list
            return View(productVMList);
        }

        public ActionResult PubHouse(string name)
        {
            // Declare a list of ProductVM
            List<ProductVM> productVMList;

            using (Db db = new Db())
            {
                // Get category id
                PubHouseDTO pubHouseDTO = db.PubHouses.Where(x => x.Slug == name).FirstOrDefault();
                int pubId = pubHouseDTO.Id;


                // Init the list
                productVMList = db.Products.ToArray().Where(x => x.PubHouseId == pubId).Select(x => new ProductVM(x)).ToList();

                // Get category name
                var productPub = db.Products.Where(x => x.PubHouseId == pubId).FirstOrDefault();
                ViewBag.PubHouseName = productPub.PubHouseName;
            }

            // Return view with list
            return View(productVMList);
        }

        
            // GET: /shop/product-details/name
            [ActionName("product-details")]
            public ActionResult ProductDetails(string name)
            {
                // Declare the VM and DTO
                ProductVM model;
                ProductDTO dto;

                // Init product id
                int id = 0;

                using (Db db = new Db())
                {
                    // Check if product exists
                    if (!db.Products.Any(x => x.Slug.Equals(name)))
                    {
                        return RedirectToAction("Index", "Shop");
                    }

                    // Init productDTO
                    dto = db.Products.Where(x => x.Slug == name).FirstOrDefault();

                    // Get id
                    id = dto.Id;

                    // Init model
                    model = new ProductVM(dto);
                }

                // Get gallery images
                model.GalleryImages = Directory.EnumerateFiles(Server.MapPath("~/Images/Uploads/Products/" + id + "/Gallery/Thumbs"))
                                                    .Select(fn => Path.GetFileName(fn));

                // Return view with model
                return View("ProductDetails", model);
            }
    }
}
