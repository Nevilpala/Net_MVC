

using API_Jewelley_Management.DAL;
using API_Jewelley_Management.Models;
using System.Reflection.Metadata.Ecma335;

namespace API_Jewelley_Management.BAL
{
    public class Category_BAL
    {
        Category_DALBase dal = new Category_DALBase();
           
        #region API_Category_SelectALL
        public List<CategoryModel> API_Category_SelectALL()
        { 
           return dal.API_Category_SelectALL(); 
        }
        #endregion

        #region API_Category_SelectByID
        public CategoryModel API_Category_SelectByID(int ID)
        { 
            return dal.API_Category_SelectByID(ID);
        }
        #endregion
         
        #region API_Category_Insert
        public bool API_Category_Insert(CategoryModel model)
        {
            return dal.API_Category_Insert(model);
        }
        #endregion

        #region API_Category_Update
        public bool API_Category_Update(CategoryModel model)
        {
            return dal.API_Category_Update(model);
        }
        #endregion

        #region API_Category_Delete
        public bool API_Category_Delete(int ID)
        {
            return dal.API_Category_Delete(ID);
        }
        #endregion 

    }
}
