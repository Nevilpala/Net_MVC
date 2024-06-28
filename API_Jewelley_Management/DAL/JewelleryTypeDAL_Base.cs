using API_Jewelley_Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using System.Collections.Generic;

namespace API_Jewelley_Management.DAL
{
    public class JewelleryTypeDAL_Base : DAL_Helper
    {

        #region API_JewelleryType_SelectALL
        public List<JewelleryTypeModel> API_JewelleryType_SelectALL()
        {
            try
            {
                List<JewelleryTypeModel> list = new List<JewelleryTypeModel>();
                SqlDatabase sqlDatabase = new SqlDatabase(connStr);
                DbCommand DbCmd = sqlDatabase.GetStoredProcCommand("API_JewelleryType_SelectALL");
                using (IDataReader dr = sqlDatabase.ExecuteReader(DbCmd))
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

        #region API_JewelleryType_SelectByID
        public JewelleryTypeModel API_JewelleryType_SelectByID(int ID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_JewelleryType_SelectByID");
                sqldb.AddInParameter(cmd, "@JewelleryTypeID", DbType.Int32, ID);
                JewelleryTypeModel model = new JewelleryTypeModel();
                using (IDataReader dr = sqldb.ExecuteReader(cmd))
                {
                    dr.Read(); 
                    model.JewelleryTypeID = Convert.ToInt32(dr["JewelleryTypeID"].ToString());
                    model.JewelleryTypeName = dr["JewelleryTypeName"].ToString(); 
                }
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region API_JewelleryType_Insert
        public bool API_JewelleryType_Insert(JewelleryTypeModel model)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_JewelleryType_Insert");
                sqldb.AddInParameter(cmd, "@JewelleryTypeName", DbType.String, model.JewelleryTypeName); 
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

        #region API_JewelleryType_Update
        public bool API_JewelleryType_Update(JewelleryTypeModel model)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_JewelleryType_Update");
                sqldb.AddInParameter(cmd, "@JewelleryTypeID", DbType.Int32, model.JewelleryTypeID);
                sqldb.AddInParameter(cmd, "@JewelleryTypeName", DbType.String, model.JewelleryTypeName); 
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

        #region API_JewelleryType_Delete

        public bool API_JewelleryType_Delete(int ID)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(connStr);
                DbCommand cmd = sqldb.GetStoredProcCommand("API_JewelleryType_Delete");
                sqldb.AddInParameter(cmd, "@JewelleryTypeID", DbType.Int32, ID);
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
