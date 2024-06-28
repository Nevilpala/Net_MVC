
namespace API_Jewelley_Management.DAL
{
	public class DAL_Helper 
	{
		public static string connStr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("myConnectionString");

	}
}
