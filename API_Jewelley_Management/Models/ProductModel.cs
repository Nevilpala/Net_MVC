namespace API_Jewelley_Management.Models

{
	public class ProductModel
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; } = string.Empty;
		public string? ProductCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
		 
		public decimal Discount { get; set; }
		public decimal Price { get; set; }
		public decimal SellPrice { get; set; }

		public int Quantity { get; set; } 
		public decimal Rating { get; set; }

		public int? CategoryID { get; set; } = null;
		public int? SubCategoryID { get; set; } = null;

		public string? CategoryName { get; set; }
		public string? SubCategoryName { get; set; }

		public Dictionary<string,dynamic> Specifications { get; set; } = new Dictionary<string,dynamic>();
		public List<string> ImageUrls { get; set; } = new List<string>();
        public int? JewelleryTypeID { get; set; } = null;
        public string? JewelleryTypeName { get; set; }
		public int? CartQuantity { get; set; } = null;
		 
    }
}
