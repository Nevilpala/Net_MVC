using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using API_Jewelley_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Jewelley_Management.DAL
{
    public class Dropdown_DALBase : DAL_Helper
    {
		#region API_Category_Dropdown
		public List<CategoryDropdown> API_Category_Dropdown()
        {
            try
            {
                List<CategoryDropdown> list = new List<CategoryDropdown>();
                SqlDatabase sqlDatabase = new SqlDatabase(connStr);
                DbCommand DbCmd = sqlDatabase.GetStoredProcCommand("API_Category_Dropdown");
                using (IDataReader dr = sqlDatabase.ExecuteReader(DbCmd))
                {

                    while (dr.Read())
                    {
                        CategoryDropdown model = new CategoryDropdown();
                        model.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                        model.CategoryName = dr["CategoryName"].ToString();
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

		#region API_SubCategory_Dropdown_BY_ID
		public List<SubCategoryDropdown> API_SubCategory_Dropdown_BY_ID(int ID = 0)
        {
            try
            {
				List<SubCategoryDropdown> list = new List<SubCategoryDropdown>();

				SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_SubCategory_Dropdown");
                if(ID!=0)
                {
					sqldb.AddInParameter(cmd, "@CategoryID", DbType.Int32, ID);

				}
				using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        SubCategoryDropdown model = new SubCategoryDropdown(); 
                        model.SubCategoryID = Convert.ToInt32(dr["SubCategoryID"].ToString());
                        model.CategoryID = Convert.ToInt32(dr["CategoryID"].ToString());
                        model.SubCategoryName = dr["SubCategoryName"].ToString();
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

        #region API_JewelleryWithSpecification_Dropdown
        //public List<SpecificationModel> API_JewelleryWithSpecification_Dropdown(int? ID =0)
        //{
        //    try
        //    {
        //        List<SpecificationModel> list = new List<SpecificationModel>();
        //        DataTable dt = new DataTable(); 
        //        SqlDatabase sqldb = new SqlDatabase(connStr);
        //        DbCommand cmd = sqldb.GetStoredProcCommand("API_JewelleryWithSpecification_Dropdown");
        //        if (ID != 0)
        //        {
        //            sqldb.AddInParameter(cmd, "@TypeID", DbType.Int32, ID);
                            
        //        }
        //        using (IDataReader dr = sqldb.ExecuteReader(cmd))
        //        {
        //            dt.Load(dr);
        //            //while (dr.Read())
        //            //{
        //            //    //SpecificationModel model = new SpecificationModel(); 
        //            //    //model.JewelleryTypeID = Convert.ToInt32(dr["JewelleryTypeID"].ToString());
        //            //    //model.JewelleryTypeName = dr["JewelleryTypeName"].ToString();

        //            //    //list.Add(model);
        //            //}

        //        }
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        public List<JewelleryWithSpecification_Dropdown> API_JewelleryWithSpecification_Dropdown(int ID)
        {
            try
            {
                List<JewelleryWithSpecification_Dropdown> list = new List<JewelleryWithSpecification_Dropdown>(); 
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_JewelleryTypeSpecification_Dropdown");
                if (ID != 0)
                {
                    sqldb.AddInParameter(cmd, "@TypeID", DbType.Int32, ID);

                }
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                { 
                    while (dr.Read())
                    {
                        JewelleryWithSpecification_Dropdown model = new JewelleryWithSpecification_Dropdown();
                        model.JewelleryTypeID = Convert.ToInt32(dr["JewelleryTypeID"].ToString());
                        model.JewelleryTypeName = dr["JewelleryTypeName"].ToString();
                        model.Specifications = (dr["Specifications"].ToString()).Split(",,").ToList<string>();

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


        #region API_JewelleryType_Dropdown
        public List<JewelleryTypeModel> API_JewelleryType_Dropdown()
        {
            try
            {
                List<JewelleryTypeModel> list = new List<JewelleryTypeModel>();

                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_JewelleryType_Dropdown");
           
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        JewelleryTypeModel model = new JewelleryTypeModel();
                        model.JewelleryTypeID = Convert.ToInt32(dr["JewelleryTypeID"].ToString()); 
                        model.JewelleryTypeName = dr["JewelleryTypeName"].ToString();
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


    }
}
