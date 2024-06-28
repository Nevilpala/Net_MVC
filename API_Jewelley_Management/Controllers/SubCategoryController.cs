using API_Jewelley_Management.BAL;
using API_Jewelley_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Jewelley_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class SubCategoryController : Controller
    {
        SubCategory_BAL bal = new SubCategory_BAL();
        CommonFunction res = new CommonFunction();

        #region API_SubCategory_SelectALL
        [HttpGet]
        public IActionResult Get()
        {
            return res.Common_SelectALl(bal.API_SubCategory_SelectALL());
        }

        #endregion

        #region API_SubCategory_SelectByID

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        { 
            return res.Common_SelectByID(bal.API_SubCategory_SelectByID(id));
        }
        #endregion

        #region API_SubCategory_Insert

        [HttpPost]
        [Authorize]

        public IActionResult Post([FromBody] SubCategoryModel subCategoryModel)
        {
            return res.Common_Insert(bal.API_SubCategory_Insert(subCategoryModel));
        }
        #endregion

        #region API_SubCategory_Update

        [HttpPut("{id}")]
        [Authorize]

        public IActionResult Put(int id, [FromBody] SubCategoryModel subCategoryModel)
        {
            subCategoryModel.SubCategoryID = id;
            return res.Common_Update(bal.API_SubCategory_Update(subCategoryModel));
        }
        #endregion

        #region API_SubCategory_Delete
        [HttpDelete("{id}")]
        [Authorize]

        public IActionResult Delete(int id)
        {
            return res.Common_Delete(bal.API_SubCategory_Delete(id));
        }
        #endregion
    }
}
