using API_Jewelley_Management.BAL;
using API_Jewelley_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Jewelley_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        Product_BAL bal = new Product_BAL();
        CommonFunction res = new CommonFunction();

        #region API_Product_SelectALL
        [HttpGet] 
        public IActionResult Get()
        {
            return res.Common_SelectALl(bal.API_Product_SelectALL());
        }
        #endregion


        #region API_Product_Filter
        [HttpPost("Filter")]
        public IActionResult Post([FromBody] ProductFilterOption op)
        {
            return res.Common_SelectALl(bal.API_Product_Filter(op));
        }

        #endregion

        #region API_Product_SelectByID

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return res.Common_SelectByID(bal.API_Product_SelectByID(id));
        }
        #endregion

        #region API_Product_Insert

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] ProductModel model)
        {
            return res.Common_Insert(bal.API_Product_Insert(model));
        }
        #endregion

        #region API_Product_Update

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductModel model)
        {
            model.ProductID = id;
            return res.Common_Update(bal.API_Product_Update(model));
        }
        #endregion

        #region API_Product_Delete
        [HttpDelete("{id}")]
        [Authorize]

        public IActionResult Delete(int id)
        {
            return res.Common_Delete(bal.API_Product_Delete(id));
        }
        #endregion
    }
}
