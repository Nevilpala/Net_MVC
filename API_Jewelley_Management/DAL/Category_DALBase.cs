using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using API_Jewelley_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Jewelley_Management.DAL
{
    public class Category_DALBase : DAL_Helper
    {
        #region API_Category_SelectALL
        public List<CategoryModel> API_Category_SelectALL()
        {
            try
            {
                List<CategoryModel> list = new List<CategoryModel>();
                SqlDatabase sqlDatabase = new SqlDatabase(connStr);
                DbCommand DbCmd = sqlDatabase.GetStoredProcCommand("API_Category_SelectALL");
                using (IDataReader dr = sqlDatabase.ExecuteReader(DbCmd))
                {

                    while (dr.Read())
                    {
                        CategoryModel model = new CategoryModel();
                        model.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                        model.CategoryName = dr["CategoryName"].ToString();
                        model.Description = dr["Description"].ToString();
                        model.SubCategoryCount = Convert.ToInt32(dr["SubCategoryCount"].ToString());
                        model.ProductCount = Convert.ToInt32(dr["ProductCount"].ToString());
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

        #region API_Category_SelectByID
        public CategoryModel API_Category_SelectByID(int ID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Category_SelectByID");
                sqldb.AddInParameter(cmd, "@CategoryID", DbType.Int32, ID);
                CategoryModel model = new CategoryModel();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    dr.Read();

                    model.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                    model.CategoryName = dr["CategoryName"].ToString();
                    model.Description = dr["Description"].ToString(); 
                    model.SubCategoryCount = Convert.ToInt32(dr["SubCategoryCount"].ToString());
                    model.ProductCount = Convert.ToInt32(dr["ProductCount"].ToString());
                }
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region API_Category_Insert
        public bool API_Category_Insert(CategoryModel categoryModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Category_Insert"); 
                sqldb.AddInParameter(cmd, "@CategoryName", DbType.String, categoryModel.CategoryName);
                sqldb.AddInParameter(cmd, "@Description", DbType.String, categoryModel.Description); 
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

        #region API_Category_Update
        public bool API_Category_Update(CategoryModel categoryModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Category_Update");
                sqldb.AddInParameter(cmd, "@CategoryID", DbType.Int32, categoryModel.CategoryID);
                sqldb.AddInParameter(cmd, "@CategoryName", DbType.String, categoryModel.CategoryName);
                sqldb.AddInParameter(cmd, "@Description", DbType.String, categoryModel.Description);
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

        #region API_Category_Delete

        public bool API_Category_Delete(int ID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Category_Delete");
                sqldb.AddInParameter(cmd, "@CategoryID", DbType.Int32, ID); 
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
