using API_Jewelley_Management.DAL;
using API_Jewelley_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Jewelley_Management.BAL
{
    public class User_BAL : Controller
    {
        User_DALBase dal = new User_DALBase();

        #region API_User_SelectALL
        public List<UserModel> API_User_SelectALL(bool? IsAdmin = null)
        {
            return dal.API_User_SelectALL(IsAdmin);
        }
        #endregion

        #region API_User_Admin
        public List<UserModel> API_User_Admin()
        {
            return dal.API_User_SelectALL(true);
        }
        #endregion

        #region API_User_Customer
        public List<UserModel> API_User_Customer()
        {
            return dal.API_User_SelectALL(false);
        }
        #endregion

        #region API_User_SelectByID
        public UserModel API_User_SelectByID(int ID)
        {
            return dal.API_User_SelectByID(ID);
        }
        #endregion

        #region API_User_Insert
        public bool API_User_Insert(UserModel model)
        {
            return dal.API_User_Insert(model);
        }
        #endregion

        #region API_User_Update
        public bool API_User_Update(UserModel model)
        {
            return dal.API_User_Update(model);
        }
        #endregion

        #region API_User_Delete
        public bool API_User_Delete(int ID)
        {
            return dal.API_User_Delete(ID);
        }
        #endregion
    }
}
