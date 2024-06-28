using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace API_Jewelley_Management.DAL
{
	public class Account_DALBase : DAL_Helper
	{
        #region API_Login_Check
        public AccountModel API_Login_Check(string Username, string Password)
		{
			try
			{
				SqlDatabase sqlDatabase = new SqlDatabase(connStr);
				DbCommand DbCmd = sqlDatabase.GetStoredProcCommand("API_Login_Check");
				sqlDatabase.AddInParameter(DbCmd, "@Username", SqlDbType.VarChar, Username);
				sqlDatabase.AddInParameter(DbCmd, "@Password", SqlDbType.VarChar, Password);
				AccountModel model = new AccountModel();
				using (IDataReader dr = sqlDatabase.ExecuteReader(DbCmd))
				{ 
					
					dr.Read();
					model.UserID = Convert.ToInt32(dr["UserID"].ToString());
					model.UserName = dr["UserName"].ToString() ;
					model.Email = dr["Email"].ToString();
					model.Phone = dr["Phone"].ToString();
					model.Address = dr["Address"].ToString() ;
					model.ImagePath = dr["Address"].ToString() ;
					model.BranchID =  Convert.ToInt32(dr["BranchID"].ToString());
					model.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
					model.IsAdmin = Convert.ToBoolean(dr["IsAdmin"].ToString());
				}
				return model;

			}
			catch (Exception ex)
			{
				return null;
			}
		}
        #endregion

        #region API_Admin_Dashboard
        public Dictionary<string,int> API_Admin_Dashboard()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(connStr);
                DbCommand DbCmd = sqlDatabase.GetStoredProcCommand("API_Admin_Dasboard");
				Dictionary<string, int> dict = new Dictionary<string, int>();


                using (IDataReader dr = sqlDatabase.ExecuteReader(DbCmd))
                {

                    dr.Read();
					dict.Add("ProductCount", Convert.ToInt32(dr["ProductCount"].ToString()));
					dict.Add("CategoryCount", Convert.ToInt32(dr["CategoryCount"].ToString()));
					dict.Add("SubCount", Convert.ToInt32(dr["SubCount"].ToString()));
					dict.Add("AdminCount", Convert.ToInt32(dr["AdminCount"].ToString()));
					dict.Add("CustomerCount", Convert.ToInt32(dr["CustomerCount"].ToString()));
					dict.Add("OrderCount", Convert.ToInt32(dr["OrderCount"].ToString()));


                }
                return dict;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

    }
}
