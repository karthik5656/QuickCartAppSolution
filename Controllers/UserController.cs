using Microsoft.AspNetCore.Mvc;
using Syren.QuickCartBL;
using Syren.QuickCartDAL.Models;

namespace Syren.WebApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        CartLogic cartLogic;
        public UserController()
        {
            cartLogic = new CartLogic();
        }

        [HttpPost]
        public int AddUser(UserModel userObj)
        {
            int result = -1;
            try
            {
                if (ModelState.IsValid)
                {
                    User u = new User();
                    u.Address = userObj.Address;
                    u.UserPassword = userObj.UserPassword;
                    u.DateOfBirth = userObj.DateOfBirth;
                    u.EmailId = userObj.EmailId;
                    u.RoleId = userObj.RoleId;
                    u.Role = userObj.Role;
                    u.Gender = userObj.Gender;
                    result = cartLogic.RegisterNewUserLogic(u);
                }
            }
            catch (Exception e)
            {
                //System.IO.File.AppendAllText("C:\\dotnet Training\\QuickartAppSolution\\stepTrack.txt",
                //    "Exception in FetchAllProducts(): " + e.Message);
            }
            return result;
        }



    }
}
