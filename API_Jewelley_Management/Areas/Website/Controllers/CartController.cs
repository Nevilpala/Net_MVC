using API_Jewelley_Management.Areas.Website.DAL;
using API_Jewelley_Management.Areas.Website.Models;
using API_Jewelley_Management.Controllers;
using API_Jewelley_Management.DAL;
using API_Jewelley_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API_Jewelley_Management.Areas.Website.Controllers
{


    [Area("Website")]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CartController : Controller
    {
        CommonFunction res = new CommonFunction();
        Cart_DALBase dal = new Cart_DALBase();


        #region API_User_CartSelectByProduct

        [HttpGet("{UserID}")]
        //[Authorize]
        public IActionResult API_Cart_SelectByProduct(int UserID)
        {
            return res.Common_SelectALl(dal.API_Cart_SelectByProduct(UserID));
        }
        #endregion
         

        #region API_Cart_Insert

        [HttpPost]
        [Authorize]
        public IActionResult InsertUpdate([FromBody] CartModel model)
        {
            return res.Common_Insert(dal.API_Cart_InsertUpdate(model));
        }
        #endregion

        #region API_Cart_Update
        [Authorize] 
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CartModel model)
        {
            model.CartID = id;
            return res.Common_Update(dal.API_Cart_Update(model));
        }
        #endregion

        #region API_Cart_Delete
        [Authorize] 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return res.Common_Delete(dal.API_Cart_Delete(id));
        }
        #endregion
    }
}
