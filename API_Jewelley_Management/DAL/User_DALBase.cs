using API_Jewelley_Management.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using System.Reflection;

namespace API_Jewelley_Management.DAL
{
    public class User_DALBase : DAL_Helper
    {
        #region API_User_SelectALL	
        public List<UserModel> API_User_SelectALL(bool? IsAdmin = null)
        {
            try
            {
                List<UserModel> list = new List<UserModel>();
                SqlDatabase sqlDatabase = new SqlDatabase(connStr);
                DbCommand DbCmd = sqlDatabase.GetStoredProcCommand("API_User_SelectALL");
                if (IsAdmin != null)
                {
                    sqlDatabase.AddInParameter(DbCmd, "@Role", DbType.Boolean, IsAdmin);
                }
                using (IDataReader dr = sqlDatabase.ExecuteReader(DbCmd))
                {

                    while (dr.Read())
                    {
                        UserModel model = new UserModel();
                        model.UserID = Convert.ToInt32(dr["UserID"].ToString());
                        model.UserName = dr["UserName"].ToString();
                        model.Email = dr["Email"].ToString();
                        model.Password = dr["Password"].ToString();
                        model.Address = dr["Address"].ToString();
                        model.Phone = dr["Phone"].ToString();
                        model.IsAdmin = Convert.ToBoolean(dr["IsAdmin"]);
                        model.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        list.Add(model);
                    }

                }
                return list;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region API_User_SelectByID
        public UserModel API_User_SelectByID(int ID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_User_SelectByID");
                sqldb.AddInParameter(cmd, "@UserID", DbType.Int32, ID);
                UserModel model = new UserModel();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    dr.Read();

                    model.UserID = Convert.ToInt32(dr["UserID"].ToString());
                    model.UserName = dr["UserName"].ToString();
                    model.Email = dr["Email"].ToString();
                    model.Password = dr["Password"].ToString();
                    model.Address = dr["Address"].ToString();
                    model.Phone = dr["Phone"].ToString();
                    model.IsAdmin = Convert.ToBoolean(dr["IsAdmin"]);
                    model.IsActive = Convert.ToBoolean(dr["IsActive"]);

                }
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region API_User_Insert
        public bool API_User_Insert(UserModel UserModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_User_Insert");
                sqldb.AddInParameter(cmd, "@UserID", DbType.Int32, UserModel.UserID);
                sqldb.AddInParameter(cmd, "@UserName", DbType.String, UserModel.UserName );
                sqldb.AddInParameter(cmd, "@Password", DbType.String, UserModel.Password);
                sqldb.AddInParameter(cmd, "@Address", DbType.String, UserModel.Address ?? null);
                sqldb.AddInParameter(cmd, "@Phone", DbType.String, UserModel.Phone ?? null);
                sqldb.AddInParameter(cmd, "@Email", DbType.String, UserModel.Email ?? null);
                sqldb.AddInParameter(cmd, "@IsAdmin", DbType.Boolean, UserModel.IsAdmin ?? null);
                sqldb.AddInParameter(cmd, "@IsActive", DbType.Boolean, UserModel.IsActive ?? null);

                if (Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion

        #region API_User_Update
        public bool API_User_Update(UserModel UserModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_User_Update");
                sqldb.AddInParameter(cmd, "@UserName", DbType.String, UserModel.UserName);
                sqldb.AddInParameter(cmd, "@Password", DbType.String, UserModel.Password);
                sqldb.AddInParameter(cmd, "@Address", DbType.String, UserModel.Address);
                sqldb.AddInParameter(cmd, "@Phone", DbType.String, UserModel.Phone);
                sqldb.AddInParameter(cmd, "@Email", DbType.String, UserModel.Email);
                sqldb.AddInParameter(cmd, "@IsAdmin", DbType.Boolean, UserModel.IsAdmin);
                sqldb.AddInParameter(cmd, "@IsActive", DbType.Boolean, UserModel.IsActive); if (Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion

        #region API_User_Delete

        public bool API_User_Delete(int ID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_User_Delete");
                sqldb.AddInParameter(cmd, "@UserID", DbType.Int32, ID);
                if (Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
                {
                    return true;
                }

                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}