namespace APIDemo.Models
{
	public class LoginModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
	public class AccountModel
	{
		public int UserID { get; set; }
		public int BranchID { get; set; } 

		public string UserName { get; set; } = string.Empty;

		public string? Email { get; set; } 

		public string? Address { get; set; }
		public string? Phone { get; set; }
		public string? ImagePath { get; set; }
		public bool IsActive { get; set; }
		public bool IsAdmin { get; set; }
	}
}
