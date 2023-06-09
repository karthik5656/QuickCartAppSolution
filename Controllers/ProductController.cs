using Microsoft.AspNetCore.Mvc;
using Syren.QuickCartBL;
using Syren.QuickCartDAL.Models;

namespace Syren.WebApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        CartLogic cartLogic;

        public ProductController()
        {
            cartLogic = new CartLogic();
        }

        [HttpGet]
        public JsonResult FetchProductByCategory(byte categoryId)
        {
            Product productObj = null;
            try
            {
                productObj = cartLogic.FilterProducts(categoryId);
            }
            catch (Exception e)
            {
                //Exceptions will be logged into the stepTrack.txt file
                //System.IO.File.AppendAllText("C:\\dotnet Training\\QuickartAppSolution\\stepTrack.txt",
                //    "Exception in FetchProductByCategory(): " + e.Message);
            }
            return Json(productObj);
        }

        [HttpGet]
        public JsonResult FetchAllProductsByCategoryId(byte categoryId)
        {
            List<Product> productList = null;
            try
            {
                productList = cartLogic.GetProductsByCategoryId(categoryId);
            }
            catch (Exception e)
            {
                ////Exceptions will be logged into the stepTrack.txt file
                //System.IO.File.AppendAllText("C:\\dotnet Training\\QuickartAppSolution\\stepTrack.txt",
                //    "Exception in FetchAllProductsByCategoryId(): " + e.Message);
            }
            return Json(productList);
        }

        [HttpGet]
        public JsonResult FetchAllProducts()
        {
            List<Product> productList = null;
            try
            {
                productList = cartLogic.GetAllProductsLogic();
            }
            catch (Exception e)
            {
                ////Exceptions will be logged into the stepTrack.txt file
                //System.IO.File.AppendAllText("C:\\dotnet Training\\QuickartAppSolution\\stepTrack.txt",
                //    "Exception in FetchAllProducts(): " + e.Message);
            }
            return Json(productList);
        }


        [HttpPost]
        public bool AddProduct(ProductM prodObj)
        {
            bool result = false;
            try
            {
                if (ModelState.IsValid)
                {
                    Product product = new Product();
                    product.ProductId = prodObj.ProductId;
                    product.CategoryId = prodObj.CategoryId;
                    product.ProductName = prodObj.ProductName;
                    product.Price = prodObj.Price;
                    result = cartLogic.AddProduct(product);
                    //Console.WriteLine(result);
                }
            }
            catch (Exception e)
            {
                //System.IO.File.AppendAllText("C:\\dotnet Training\\QuickartAppSolution\\stepTrack.txt",
                //    "Exception in FetchAllProducts(): " + e.Message);
            }
            return result;
        }

        [HttpPut]
        public int UpdateProduct(ProductM prodObj)
        {
            int result = -1;
            try
            {
                if (ModelState.IsValid)
                {
                    Product product = new Product();
                    product.ProductId = prodObj.ProductId;
                    product.CategoryId = prodObj.CategoryId;
                    product.ProductName= prodObj.ProductName;
                    product.Price = prodObj.Price;
                    product.QuantityAvailable = prodObj.QuantityAvailable;
                    result = cartLogic.UpdateProductLogic(product);
                }
            }
            catch (Exception e)
            {
                //System.IO.File.AppendAllText("C:\\dotnet Training\\QuickartAppSolution\\stepTrack.txt",
                //    "Exception in FetchAllProducts(): " + e.Message);
            }
            return result;
        }

        [HttpDelete]
        public bool DeleteProduct(string productId)
        {
            bool result = false;
            try
            {
                if (ModelState.IsValid)
                {
                    result = cartLogic.DeleteProductLogic(productId);
                }
            }
            catch (Exception e)
            {
                //System.IO.File.AppendAllText("C:\\dotnet Training\\QuickartAppSolution\\stepTrack.txt",
                //    "Exception in DeleteProduct(): " + e.Message);
            }
            return result;
        }
    }
}
