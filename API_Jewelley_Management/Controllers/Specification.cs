using API_Jewelley_Management.DAL;
using API_Jewelley_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Jewelley_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Specification : Controller
    {
        Specification_DALBase bal = new Specification_DALBase();
        CommonFunction res = new CommonFunction();

        #region API_Specification_SelectALL
        [HttpGet]
        public IActionResult Get()
        {
            return res.Common_SelectALl(bal.API_Specification_SelectALL());
        }

        #endregion

        #region API_Specification_SelectByID

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return res.Common_SelectByID(bal.API_Specification_SelectByID(id));
        }
        #endregion

        #region API_Specification_Insert

        [HttpPost]
        [Authorize]

        public IActionResult Post([FromBody] SpecificationModel model)
        {
            return res.Common_Insert(bal.API_Specification_Insert(model));
        }
        #endregion

        #region API_Specification_Update

        [HttpPut("{id}")]
        [Authorize]

        public IActionResult Put(int id, [FromBody] SpecificationModel model)
        {
            model.JewelleryTypeWithSpecificationID = id;
            return res.Common_Update(bal.API_Specification_Update(model));
        }
        #endregion

        #region API_Specification_Delete
        [HttpDelete("{id}")]
        [Authorize]

        public IActionResult Delete(int id)
        {
            return res.Common_Delete(bal.API_Specification_Delete(id));
        }
        #endregion
    }
}
