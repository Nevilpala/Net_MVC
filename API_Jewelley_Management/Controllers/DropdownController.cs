using API_Jewelley_Management.BAL;
using API_Jewelley_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Jewelley_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class DropdownController : Controller
    {
        CommonFunction res = new CommonFunction();
        Dropdown_BAL bal = new Dropdown_BAL();


        #region API_Category_Dropdown
        [HttpGet("Category")]
        public IActionResult CategoryDropdown()
        {
            return res.Common_SelectALl(bal.API_Category_Dropdown());
        }
        #endregion

        #region API_SubCategory_Dropdown
        [HttpGet("SubCategory")]
        public IActionResult SubCategoryDropdown()
        {
            return res.Common_SelectALl(bal.API_SubCategory_Dropdown());
        }

        [HttpGet("SubCategory/{CategoryID}")]
        public IActionResult SubCategoryDropdown(int CategoryID)
        {
            return res.Common_SelectALl(bal.API_SubCategory_Dropdown_BY_ID(CategoryID));
        }
        #endregion



        #region API_Specification_Dropdown
        [HttpGet("Specification")]
        public IActionResult SpecificationDropdown()
        {
            return res.Common_SelectALl(bal.API_JewelleryWithSpecification_Dropdown());
        }
        [HttpGet("Specification/{ID}")]

        public IActionResult SpecificationDropdown(int ID)
        {
            return res.Common_SelectALl(bal.API_JewelleryWithSpecification_Dropdown(ID));
        }
        #endregion

        #region API_JewelleryType_Dropdown
        [HttpGet("JewelleryType")]
        public IActionResult JewelleryTypeDropdown()
        {
            return res.Common_SelectALl(bal.API_JewelleryType_Dropdown());
        }
        #endregion

    }
}
