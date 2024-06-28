using API_Jewelley_Management.DAL;
using API_Jewelley_Management.Models;
using System.Data;

namespace API_Jewelley_Management.BAL
{
    public class Dropdown_BAL
    {
        Dropdown_DALBase dal = new Dropdown_DALBase();

        #region API_Category_Dropdown

        public List<CategoryDropdown> API_Category_Dropdown()
        {
            return dal.API_Category_Dropdown();
        }

        #endregion


        #region API_SubCategory_Dropdown

        public List<SubCategoryDropdown> API_SubCategory_Dropdown()
        {
            return dal.API_SubCategory_Dropdown_BY_ID();
        }

        public List<SubCategoryDropdown> API_SubCategory_Dropdown_BY_ID(int ID)
        {
            return dal.API_SubCategory_Dropdown_BY_ID(ID);
        }

        #endregion



        public List<JewelleryWithSpecification_Dropdown> API_JewelleryWithSpecification_Dropdown(int ID = 0)
        {

            return dal.API_JewelleryWithSpecification_Dropdown(ID);
        }


        public List<JewelleryTypeModel> API_JewelleryType_Dropdown()
        {
            return dal.API_JewelleryType_Dropdown();
        }
    }
}
