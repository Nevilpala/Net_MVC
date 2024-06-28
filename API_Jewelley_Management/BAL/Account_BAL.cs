using API_Jewelley_Management.Controllers;
using API_Jewelley_Management.DAL;
using APIDemo.Models;

namespace API_Jewelley_Management.BAL
{
	public class Account_BAL
	{
        Account_DALBase account_DALBase = new Account_DALBase();
		CommonFunction cf = new CommonFunction();

        public AccountModel API_Login_Check(string Username, string Password)
		{
			AccountModel accountModel = account_DALBase.API_Login_Check(Username, Password);
			if (accountModel == null )
			{
				return null;
			}
			else
			{ 
				return accountModel;
			}
		}

		public Dictionary<string, int> API_Admin_Dashboard()
		{
            Dictionary<string, int> dict = account_DALBase.API_Admin_Dashboard();
			if (dict != null){
				return dict;
			}
			return null;
        }

    }
}
