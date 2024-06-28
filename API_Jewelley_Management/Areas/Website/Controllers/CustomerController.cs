using API_Jewelley_Management.Areas.Website.DAL;
using API_Jewelley_Management.BAL;
using API_Jewelley_Management.Controllers;
using API_Jewelley_Management.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Jewelley_Management.Areas.Website.Controllers
{
    [ApiController]
    [Area("Website")]
    [Route("api/[controller]/[action]")]
    public class CustomerController : Controller
    {
        CommonFunction res = new CommonFunction();
        User_DALBase bal = new User_DALBase();
        Customer_DALBase customer_DAL = new Customer_DALBase();

        #region API_User_SelectALL
        [HttpGet]
        public IActionResult Get()
        {
            return res.Common_SelectALl(bal.API_User_SelectALL());
        }

        #endregion

        #region API_User_SelectByID

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return res.Common_SelectByID(bal.API_User_SelectByID(id));
        }
        #endregion


        #region API_User_WishList

        [HttpPost]
        public IActionResult WishListToggle(int UserID, int ProductID, [FromBody] Dictionary<string, dynamic> dict, string? ProductCode = null)
        {
            UserID = Convert.ToInt32(dict["UserID"].ToString());
            ProductID = Convert.ToInt32(dict["ProductID"].ToString());
            return res.Common_Insert(customer_DAL.API_User_WishlistToggle(UserID, ProductID, ProductCode));
        }
        #endregion

        #region API_User_SelectByALL

        [HttpGet("{UserID}")]
        public IActionResult WishListSelectALL(int UserID)
        {
            return res.Common_SelectALl(customer_DAL.API_User_WishlistSelectALL(UserID));
        }
        #endregion

        #region API_User_WishlistSelectByProduct

        [HttpGet("{UserID}")]
        [Authorize]
        public IActionResult API_User_WishlistSelectByProduct(int UserID)
        {
            return res.Common_SelectALl(customer_DAL.API_User_WishlistSelectByProduct(UserID));
        }
        #endregion


    }
}
