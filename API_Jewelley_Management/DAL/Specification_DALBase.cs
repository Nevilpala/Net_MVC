using API_Jewelley_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace API_Jewelley_Management.DAL
{
    public class Specification_DALBase : DAL_Helper
    {
        #region API_Specification_SelectALL
        public List<SpecificationModel> API_Specification_SelectALL()
        {
            try
            {
                List<SpecificationModel> list = new List<SpecificationModel>();
                SqlDatabase sqlDatabase = new SqlDatabase(connStr);
                DbCommand DbCmd = sqlDatabase.GetStoredProcCommand("API_Specification_SelectALL");
                using (IDataReader dr = sqlDatabase.ExecuteReader(DbCmd))
                {

                    while (dr.Read())
                    {
                        SpecificationModel model = new SpecificationModel();
                        model.JewelleryTypeWithSpecificationID = Convert.ToInt32(dr["JewelleryTypeWithSpecificationID"].ToString());
                        model.Name = dr["Name"].ToString(); 
                        //List<int> parts = dr["MultipleJewelleryID"].ToString().Split(',').ToList<int>();
                        var intList = new List<int>(Array.ConvertAll(dr["MultipleJewelleryID"].ToString().Split(','), Convert.ToInt32));

                        //int?[] array = Array.ConvertAll(parts, part =>
                        //{
                        //    bool success = int.TryParse(part, out int parsedNumber);
                        //    return success ? (int?)parsedNumber : null;
                        //});

                        model.MultipleTypeID = intList;

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

        #region API_Specification_SelectByID
        public SpecificationModel API_Specification_SelectByID(int ID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Specification_SelectByID");
                sqldb.AddInParameter(cmd, "@JewelleryTypeWithSpecificationID", DbType.Int32, ID);
                SpecificationModel model = new SpecificationModel();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    dr.Read();

                    model.JewelleryTypeWithSpecificationID = Convert.ToInt32(dr["JewelleryTypeWithSpecificationID"].ToString());
                    model.Name = dr["Name"].ToString();
                    //string[] parts = dr["MultipleJewelleryID"].ToString().Split(',');
                    var intList = new List<int>(Array.ConvertAll(dr["MultipleJewelleryID"].ToString().Split(','), Convert.ToInt32));

                    //int?[] array = Array.ConvertAll(parts, part =>
                    //{
                    //    bool success = int.TryParse(part, out int parsedNumber);
                    //    return success ? (int?)parsedNumber : null;
                    //});
                    model.MultipleTypeID = intList;

                }
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region API_Specification_Insert
        public bool API_Specification_Insert(SpecificationModel model)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Specification_Insert");  
                sqldb.AddInParameter(cmd, "@Name", DbType.String, model.Name);
                sqldb.AddInParameter(cmd, "@MultipleJewelleryID", DbType.String, string.Join(',', model.MultipleTypeID));
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

        #region API_Specification_Update
        public bool API_Specification_Update(SpecificationModel model)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Specification_Update");
                sqldb.AddInParameter(cmd, "@JewelleryTypeWithSpecificationID", DbType.Int32, model.JewelleryTypeWithSpecificationID); 
                sqldb.AddInParameter(cmd, "@Name", DbType.String, model.Name);
                sqldb.AddInParameter(cmd, "@MultipleJewelleryID", DbType.String, string.Join(',', model.MultipleTypeID));

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

        #region API_Specification_Delete

        public bool API_Specification_Delete(int ID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_Specification_Delete");
                sqldb.AddInParameter(cmd, "@JewelleryTypeWithSpecificationID", DbType.Int32, ID);
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
