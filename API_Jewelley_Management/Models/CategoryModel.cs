namespace API_Jewelley_Management.Models
{
    public class CategoryDropdown
    {
		public int CategoryID { get; set; }

		public string CategoryName { get; set; } = string.Empty;

	}

	public class CategoryModel : CategoryDropdown
	{ 
        public string Description { get; set; } = string.Empty;

        public int? SubCategoryCount { get; set; } = 0;
        public int? ProductCount { get; set; } = 0;
    }
     
}
