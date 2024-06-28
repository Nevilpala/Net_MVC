using API_Jewelley_Management.DAL;
using API_Jewelley_Management.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using System.Collections.Generic;
using System.Collections;

namespace API_Jewelley_Management.Areas.Website.DAL
{
    public class Customer_DALBase : DAL_Helper
    {
        public bool API_User_WishlistToggle(int UserID, int ProductID, string? ProductCode = null)
        {
            SqlDatabase sqldb = new SqlDatabase(connStr);
            DbCommand cmd = sqldb.GetStoredProcCommand("API_Customer_Wishlist");
            sqldb.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);
            sqldb.AddInParameter(cmd, "@ProductID", DbType.Int32, ProductID);
            sqldb.AddInParameter(cmd, "@ProductCode", DbType.String, ProductCode);

            if (Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<int> API_User_WishlistSelectALL(int UserID = 0)
        {
            if (UserID > 0)
            {
                List<int> list = new List<int>();
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_WishList_SelectALL");
                sqldb.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);

                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        if (dr["ProductID"] != null)
                            list.Add(Convert.ToInt32(dr["ProductID"]));
                    }

                }
                return list;
            }
            return new List<int>();
        }

        public List<ProductModel> API_User_WishlistSelectByProduct(int UserID = 0)
        {
            if (UserID > 0)
            {
                List<ProductModel> list = new List<ProductModel>();
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_WishList_SelectByProduct");
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
    }
}
