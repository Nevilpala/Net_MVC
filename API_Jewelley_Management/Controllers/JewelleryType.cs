using API_Jewelley_Management.DAL;
using API_Jewelley_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Jewelley_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JewelleryType : Controller
    {
        JewelleryTypeDAL_Base bal = new JewelleryTypeDAL_Base();
        CommonFunction res = new CommonFunction();

        #region API_JewelleryType_SelectALL
        [HttpGet]
        public IActionResult Get()
        {
            return res.Common_SelectALl(bal.API_JewelleryType_SelectALL());
        }

        #endregion

        #region API_JewelleryType_SelectByID

        [HttpGet("{id}")] 

        public IActionResult Get(int id)
        {
            return res.Common_SelectByID(bal.API_JewelleryType_SelectByID(id));
        }
        #endregion

        #region API_JewelleryType_Insert

        [HttpPost]
        [Authorize]

        public IActionResult Post([FromBody] JewelleryTypeModel model)
        {
            return res.Common_Insert(bal.API_JewelleryType_Insert(model));
        }
        #endregion

        #region API_JewelleryType_Update

        [HttpPut("{id}")]
        [Authorize]

        public IActionResult Put(int id, [FromBody] JewelleryTypeModel model)
        {
            model.JewelleryTypeID = id;
            return res.Common_Update(bal.API_JewelleryType_Update(model));
        }
        #endregion

        #region API_JewelleryType_Delete
        [HttpDelete("{id}")]
        [Authorize]

        public IActionResult Delete(int id)
        {
            return res.Common_Delete(bal.API_JewelleryType_Delete(id));
        }
        #endregion
    }
}
