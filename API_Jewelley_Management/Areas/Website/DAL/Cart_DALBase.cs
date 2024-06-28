using API_Jewelley_Management.DAL;
using API_Jewelley_Management.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using API_Jewelley_Management.Areas.Website.Models;

namespace API_Jewelley_Management.Areas.Website.DAL
{
    public class Cart_DALBase : DAL_Helper
    {
        public List<ProductModel> API_Cart_SelectByProduct(int UserID = 0)
        {
            if (UserID > 0)
            {
                List<ProductModel> list = new List<ProductModel>();
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Cart_SelectByProduct");
                sqldb.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);

                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        ProductModel model = new ProductModel();
                        Dictionary<string, dynamic> spec = new Dictionary<string, dynamic>();
                        model.ProductID = Convert.ToInt32(dr["ProductID"].ToString());
                        model.ProductName = dr["ProductName"].ToString();
                        model.ProductCode = dr["ProductCode"].ToString();
                        model.Description = dr["Description"].ToString();
                        model.Discount = (decimal)dr["Discount"];
                        model.Price = (decimal)dr["Price"];
                        model.SellPrice = (decimal)dr["SellPrice"];
                        model.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                        model.Rating = (decimal)dr["Rating"];
                        model.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                        model.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"].ToString());
                        model.CategoryName = dr["CategoryName"].ToString();
                        model.SubCategoryName = dr["SubCategoryName"].ToString();
                        model.CartQuantity = Convert.ToInt32(dr["CartQuantity"]);
                        List<string> urls = new List<string>();
                        var dataurl = dr["ImageUrls"].ToString().Split(',');

                        foreach (var s in dataurl)
                        {
                            urls.Add(s);
                        }
                        model.ImageUrls = urls;
                        list.Add(model);

                    }


                }
                return list;
            }
            return new List<ProductModel>();
        }


        #region API_Cart_Insert
        public bool API_Cart_InsertUpdate(CartModel model)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Cart_InsertUpdate");
                sqldb.AddInParameter(cmd, "@UserID", DbType.Int32, model.UserID);
                sqldb.AddInParameter(cmd, "@ProductID", DbType.Int32, model.ProductID);
                sqldb.AddInParameter(cmd, "@Quantity", DbType.Int32, model.Quantity);
                sqldb.AddInParameter(cmd, "@ProductCode", DbType.String, model.ProductCode);
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

        #region API_Cart_Update
        public bool API_Cart_Update(CartModel model)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Cart_Update");
                sqldb.AddInParameter(cmd, "@CartID", DbType.Int32, model.CartID);
                sqldb.AddInParameter(cmd, "@UserID", DbType.Int32, model.UserID);
                sqldb.AddInParameter(cmd, "@ProductID", DbType.Int32, model.ProductID);
                sqldb.AddInParameter(cmd, "@Quantity", DbType.Int32, model.Quantity);
                sqldb.AddInParameter(cmd, "@ProductCode", DbType.String, model.ProductCode);
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

        #region API_Cart_Delete

        public bool API_Cart_Delete(int ID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Cart_Delete");
                sqldb.AddInParameter(cmd, "@CartID", DbType.Int32, ID);
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
