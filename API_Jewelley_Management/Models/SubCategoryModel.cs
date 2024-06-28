namespace API_Jewelley_Management.Models
{
    public class SubCategoryDropdown
    {
		public int SubCategoryID { get; set; }

		public string SubCategoryName { get; set; }

		public int CategoryID { get; set; }

	}

	public class SubCategoryModel
    {
        public int SubCategoryID{ get; set; }

        public string? SubCategoryName { get; set; }
        
        public string? Description { get; set;}

        public string? CategoryName { get; set; }

        public int CategoryID { get; set; } 
         
        public int? ProductCount { get; set; } = 0;

    }
}
