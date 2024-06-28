using API_Jewelley_Management.DAL;
using API_Jewelley_Management.Models;

namespace API_Jewelley_Management.BAL
{
    public class SubCategory_BAL
    {
        SubCategory_DALBase dal = new SubCategory_DALBase();

        #region API_SubCategory_SelectALL
        public List<SubCategoryModel> API_SubCategory_SelectALL()
        {
            return dal.API_SubCategory_SelectALL();
        }
        #endregion

        #region API_SubCategory_SelectByID
        public SubCategoryModel API_SubCategory_SelectByID(int ID)
        {
            return dal.API_SubCategory_SelectByID(ID);
        }
        #endregion

        #region API_SubCategory_Insert
        public bool API_SubCategory_Insert(SubCategoryModel model)
        {
            return dal.API_SubCategory_Insert(model);
        }
        #endregion

        #region API_SubCategory_Update
        public bool API_SubCategory_Update(SubCategoryModel model)
        {
            return dal.API_SubCategory_Update(model);
        }
        #endregion

        #region API_SubCategory_Delete
        public bool API_SubCategory_Delete(int ID)
        {
            return dal.API_SubCategory_Delete(ID);
        }
        #endregion 
    }
}
