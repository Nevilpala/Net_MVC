using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using API_Jewelley_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace API_Jewelley_Management.DAL
{
    public class Product_DALBase : DAL_Helper
    {

      
        
        #region API_Product_SelectALL
        public List<ProductModel> API_Product_SelectALL()
        {
            try
            {
                List<ProductModel> list = new List<ProductModel>();
                SqlDatabase sqlDatabase = new SqlDatabase(connStr);
                DbCommand DbCmd = sqlDatabase.GetStoredProcCommand("API_Product_SelectALL");
                using (IDataReader dr = sqlDatabase.ExecuteReader(DbCmd))
                {

                    while (dr.Read())
                    { 
						ProductModel model = new ProductModel();
						Dictionary<string, dynamic> spec =  new Dictionary<string, dynamic>();
						model.ProductID = Convert.ToInt32(dr["ProductID"].ToString());
						model.ProductName = dr["ProductName"].ToString();
						model.ProductCode = dr["ProductCode"].ToString();
                        model.Description = dr["Description"].ToString();
						model.Discount = (decimal)dr["Discount"];
						model.Price = (decimal)dr["Price"];
						model.SellPrice = (decimal)dr["SellPrice"];
						model.Quantity = Convert.ToInt32(dr["Quantity"].ToString());  
						model.Rating = (decimal)dr["Rating"];
						model.CategoryID =  Convert.ToInt32(dr["CategoryID"].ToString());  
						model.SubCategoryID =   Convert.ToInt32(dr["SubCategoryID"].ToString()); 
						model.CategoryName =   dr["CategoryName"].ToString();  
						model.SubCategoryName =   dr["SubCategoryName"].ToString();

                        var SpecificationString = (dr["Specifications"].ToString()).Split(';');

						Console.WriteLine(SpecificationString);

						foreach (var s in SpecificationString)
                        {
							Console.WriteLine(s);

							var temp = s.Split(':');
                            spec.Add(temp[0].ToString().Trim(), temp[1].ToString().Trim());
                        }
                        model.Specifications = spec;
                        List<string> urls = new List<string>();
                        var dataurl = (dr["ImageUrls"].ToString()).Split(',');

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
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region API_Product_SelectByID
        public ProductModel API_Product_SelectByID(int ID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Product_SelectByID");
                sqldb.AddInParameter(cmd, "@ProductID", DbType.Int32, ID);  
                ProductModel model = new ProductModel();
				Dictionary<string, dynamic> spec = new Dictionary<string, dynamic>();

				using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    dr.Read(); 
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

					var SpecificationString = (dr["Specifications"].ToString()).Split(';');

					Console.WriteLine(SpecificationString);

					foreach (var s in SpecificationString)
					{
						Console.WriteLine(s);

						var temp = s.Split(':');
						spec.Add(temp[0].ToString().Trim(), temp[1].ToString().Trim());
					}
					model.Specifications = spec;
                    List<string> urls = new List<string>();

                    foreach (var s in (dr["ImageUrls"].ToString().Split(',')))
                    {
                        urls.Add(s);
                    }
                    model.ImageUrls = urls;
                }

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

		#endregion
		#region API_Product_Insert
        public bool API_Product_Insert(ProductModel model)
        {
            try
            {
                DataTable specTable = new DataTable();
                specTable.Columns.Add("SpecificationName", typeof(string));
                specTable.Columns.Add("SpecificationValue", typeof(string));

                foreach (var spec in model.Specifications)
                {
                    specTable.Rows.Add(spec.Key, spec.Value);
                }
                string urls = string.Join(",", model.ImageUrls);
                Console.WriteLine(urls);
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_ProductWithSpecification_Insert");
                sqldb.AddInParameter(cmd, "@ProductName", DbType.String, model.ProductName);
                sqldb.AddInParameter(cmd, "@Description", DbType.String, model.Description);
                sqldb.AddInParameter(cmd, "@Discount", DbType.Decimal, model.Discount);
                sqldb.AddInParameter(cmd, "@Price", DbType.Decimal, model.Price);
                sqldb.AddInParameter(cmd, "@SellPrice", DbType.Decimal, model.SellPrice);
                sqldb.AddInParameter(cmd, "@Rating", DbType.Decimal, model.Rating);
                sqldb.AddInParameter(cmd, "@CategoryID", DbType.Int32, model.CategoryID);
                sqldb.AddInParameter(cmd, "@SubCategoryID", DbType.Int32, model.SubCategoryID);
                sqldb.AddInParameter(cmd, "@Quantity", DbType.Int32, model.Quantity);
                sqldb.AddInParameter(cmd, "@ImageUrls", DbType.String, urls);


                // Cast the DbCommand to SqlCommand to access SqlCommand specific features like Parameters for table-valued parameter
                SqlCommand sqlCommand = (SqlCommand)cmd;

                SqlParameter specParam = sqlCommand.Parameters.AddWithValue("@Specifications", specTable);
                specParam.SqlDbType = SqlDbType.Structured;
                specParam.TypeName = "dbo.ProductWiseSpecificationType";

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

        #region API_Product_Update
        public bool API_Product_Update(ProductModel model)
        {
            try
            {
                DataTable specTable = new DataTable();
                specTable.Columns.Add("SpecificationName", typeof(string));
                specTable.Columns.Add("SpecificationValue", typeof(string));

                foreach (var spec in model.Specifications)
                {
                    specTable.Rows.Add(spec.Key, spec.Value);
                }
                string urls = string.Join(",", model.ImageUrls);

                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_ProductWithSpecification_Update");

                sqldb.AddInParameter(cmd, "@ProductID", DbType.Int32, model.ProductID);
                sqldb.AddInParameter(cmd, "@ProductName", DbType.String, model.ProductName);
                sqldb.AddInParameter(cmd, "@Description", DbType.String, model.Description);
                sqldb.AddInParameter(cmd, "@Discount", DbType.Decimal, model.Discount);
                sqldb.AddInParameter(cmd, "@Price", DbType.Decimal, model.Price);
                sqldb.AddInParameter(cmd, "@SellPrice", DbType.Decimal, model.SellPrice);
                sqldb.AddInParameter(cmd, "@Rating", DbType.Decimal, model.Rating);
                sqldb.AddInParameter(cmd, "@CategoryID", DbType.Int32, model.CategoryID);
                sqldb.AddInParameter(cmd, "@SubCategoryID", DbType.Int32, model.SubCategoryID);
                sqldb.AddInParameter(cmd, "@Quantity", DbType.Int32, model.Quantity);
                sqldb.AddInParameter(cmd, "@ImageUrls", DbType.String, urls);


                // Cast the DbCommand to SqlCommand to access SqlCommand specific features like Parameters for table-valued parameter
                SqlCommand sqlCommand = (SqlCommand)cmd;

                SqlParameter specParam = sqlCommand.Parameters.AddWithValue("@Specifications", specTable);
                specParam.SqlDbType = SqlDbType.Structured;
                specParam.TypeName = "dbo.ProductWiseSpecificationType";

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

        #region API_Product_Delete

        public bool API_Product_Delete(int ID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Product_DeletePermenent");
                sqldb.AddInParameter(cmd, "@ProductID", DbType.Int32, ID); 
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
