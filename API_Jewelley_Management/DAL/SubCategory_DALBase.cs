using API_Jewelley_Management.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace API_Jewelley_Management.DAL
{
    public class SubCategory_DALBase : DAL_Helper
    {
        #region API_SubCategory_SelectALL
        public List<SubCategoryModel> API_SubCategory_SelectALL()
        {
            try
            {
                List<SubCategoryModel> list = new List<SubCategoryModel>();
                SqlDatabase sqlDatabase = new SqlDatabase(connStr);
                DbCommand DbCmd = sqlDatabase.GetStoredProcCommand("API_SubCategory_SelectALL");
                using (IDataReader dr = sqlDatabase.ExecuteReader(DbCmd))
                {

                    while (dr.Read())
                    {
                        SubCategoryModel model = new SubCategoryModel();
                        model.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"].ToString());
                        model.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                        model.SubCategoryName = dr["SubCategoryName"].ToString();
                        model.CategoryName = dr["CategoryName"].ToString();
                        model.ProductCount = Convert.ToInt32(dr["ProductCount"].ToString());

                        model.Description = dr["Description"].ToString();
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

        #region API_SubCategory_SelectByID
        public SubCategoryModel API_SubCategory_SelectByID(int ID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_SubCategory_SelectByID");
                sqldb.AddInParameter(cmd, "@SubCategoryID", DbType.Int32, ID);
                SubCategoryModel model = new SubCategoryModel();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    dr.Read();

                    model.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"].ToString());
                    model.ProductCount = Convert.ToInt32(dr["ProductCount"].ToString());
                    model.SubCategoryName = dr["SubCategoryName"].ToString();
                    model.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                    model.CategoryName = dr["CategoryName"].ToString();
                    model.Description = dr["Description"].ToString();

                }
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region API_SubCategory_Insert
        public bool API_SubCategory_Insert(SubCategoryModel subCategoryModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_SubCategory_Insert"); 
                sqldb.AddInParameter(cmd, "@CategoryID", DbType.Int32, subCategoryModel.CategoryID);
                sqldb.AddInParameter(cmd, "@SubCategoryName", DbType.String, subCategoryModel.SubCategoryName);
                sqldb.AddInParameter(cmd, "@Description", DbType.String, subCategoryModel.Description);
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

        #region API_SubCategory_Update
        public bool API_SubCategory_Update(SubCategoryModel subCategoryModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_SubCategory_Update");
                sqldb.AddInParameter(cmd, "@SubCategoryID", DbType.String, subCategoryModel.SubCategoryID);
                sqldb.AddInParameter(cmd, "@CategoryID", DbType.String, subCategoryModel.CategoryID);
                sqldb.AddInParameter(cmd, "@SubCategoryName", DbType.String, subCategoryModel.SubCategoryName);
                sqldb.AddInParameter(cmd, "@Description", DbType.String, subCategoryModel.Description);
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

        #region API_SubCategory_Delete

        public bool API_SubCategory_Delete(int ID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_SubCategory_Delete");
                sqldb.AddInParameter(cmd, "@SubCategoryID", DbType.Int32, ID);
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
