using API_Jewelley_Management.BAL;
using API_Jewelley_Management.DAL;
using API_Jewelley_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Jewelley_Management.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : Controller
	{
		CommonFunction res = new CommonFunction();
		User_BAL bal = new User_BAL();

		#region API_User_SelectALL
		[HttpGet]
		public IActionResult Get()
		{
			return res.Common_SelectALl(bal.API_User_SelectALL());
		}

        #endregion

        #region API_User_SelectALL
        [HttpGet("Admin")]
        public IActionResult GetAdmin()
        {
            return res.Common_SelectALl(bal.API_User_Admin());
        }

        #endregion

        #region API_User_SelectALL
        [HttpGet("Customer")]
        public IActionResult GetCustomer()
        {
            return res.Common_SelectALl(bal.API_User_Customer());
        }

        #endregion

        #region API_User_SelectByID

        [HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return res.Common_SelectByID(bal.API_User_SelectByID(id));
		}
		#endregion

		#region API_User_Insert

		[HttpPost]
		public IActionResult Post([FromBody] UserModel model)
		{
			return res.Common_Insert(bal.API_User_Insert(model));
		}
		#endregion

		#region API_User_Update

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] UserModel model)
		{
			model.UserID = id;
			return res.Common_Update(bal.API_User_Update(model));
		}
		#endregion

		#region API_User_Delete
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			return res.Common_Delete(bal.API_User_Delete(id));
		}
		#endregion


	}
}
