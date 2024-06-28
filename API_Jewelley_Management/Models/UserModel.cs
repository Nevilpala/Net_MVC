namespace API_Jewelley_Management.Models
{
	public class UserModel
	{
		public int UserID { get; set; }

		public string UserName { get; set; } = string.Empty;
 
		public string Password { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;
		public bool? IsAdmin { get; set; }
		public bool? IsActive { get; set; }
		public string? Address { get; set; } = string.Empty;
		public string? Phone { get; set; } = string.Empty;

    }
}
