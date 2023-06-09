using Microsoft.AspNetCore.Mvc;
using Syren.QuickCartBL;
using Syren.QuickCartDAL.Models;

namespace Syren.WebAPI.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : Controller
    {
        CartLogic cartLogic;
        public CategoryController()
        {
            cartLogic = new CartLogic();
        }

        [HttpGet]
        public JsonResult FetchAllCategories()
        {
            List<Category> categoriesList = null;
            try
            {
                categoriesList = cartLogic.GetAllCategoriesLogic();
            }
            catch (Exception e)
            {
                //Exceptions will be logged into the stepTrack.txt file
                //System.IO.File.AppendAllText("C:\\dotnet Training\\QuickartAppSolution\\stepTrack.txt",
                //    "Exception in FetchAllCategories(): " + e.Message);
            }
            return Json(categoriesList);
        }

        [HttpPost]
        public int AddCategory(CategoryM catObj)
        {
            int result = -1;
            //byte catgoryId;
            try
            {
                if(ModelState.IsValid)
                {
                    Category category = new Category();
                    category.CategoryId = catObj.CategoryId;
                    category.CategoryName = catObj.CategoryName;
                    result = cartLogic.AddCategoriesLogic(category);
                }
                else
                {
                    result = -99;
                }
                
            }
            catch (Exception e)
            {
                //System.IO.File.AppendAllText("C:\\dotnet Training\\QuickartAppSolution\\stepTrack.txt",
                //    "Exception in AddCategory(): " + e.Message);
            }
            return result;
        }

        [HttpPut]
        public bool UpdateCategory(CategoryM catObj)
        {
            bool result = false;
            try
            {
                if(ModelState.IsValid)
                {
                    Category category = new Category();
                    category.CategoryName= catObj.CategoryName;
                    category.CategoryId = catObj.CategoryId;

                    result = cartLogic.UpdateCategoryLogic(category);
                }

            }
            catch (Exception e)
            {
                //System.IO.File.AppendAllText("C:\\dotnet Training\\QuickartAppSolution\\stepTrack.txt",
                //    "Exception in AddCategory(): " + e.Message);
            }
            return result;
        }

        

    }
}
