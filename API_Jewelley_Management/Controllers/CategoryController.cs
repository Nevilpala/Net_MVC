using API_Jewelley_Management.BAL;
using API_Jewelley_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
 
namespace API_Jewelley_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CategoryController : Controller
    {
        Category_BAL bal = new Category_BAL();
        CommonFunction res = new CommonFunction();

        #region API_Category_SelectALL
        [HttpGet]
        public IActionResult Get()
        { 
            return res.Common_SelectALl(bal.API_Category_SelectALL());
        }

        #endregion

        #region API_Category_SelectByID
          
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        { 
            return res.Common_SelectByID(bal.API_Category_SelectByID(id));
        }
        #endregion

        #region API_Category_Insert

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CategoryModel categoryModel)
        {
            return res.Common_Insert(bal.API_Category_Insert(categoryModel));
        }
        #endregion

        #region API_Category_Update
        [Authorize]

        [HttpPut("{id}")]
        public IActionResult Put(int id , [FromBody] CategoryModel categoryModel)
        {
            categoryModel.CategoryID = id;
            return res.Common_Update(bal.API_Category_Update(categoryModel));
        }
        #endregion

        #region API_Category_Delete
        [Authorize]

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            return res.Common_Delete(bal.API_Category_Delete(id));
        }
        #endregion
    }
}
