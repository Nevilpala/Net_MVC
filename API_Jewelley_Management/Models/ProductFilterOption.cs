namespace API_Jewelley_Management.Models
{
    public class ProductFilterOption
    {

        public List<int>? CategoryIds { get; set; } = null; // Changed to List<int>?
        public List<int>? SubCategoryIds { get; set; } = null; // Changed to List<int>?
        public decimal? MinPrice { get; set; } = null;
        public decimal? MaxPrice { get; set; } = null;
        public int? MinQuantity { get; set; } = null;
        public decimal? MinRating { get; set; } = null;
        public string SearchQuery { get; set; } = string.Empty;
        public string SortBy { get; set; } = string.Empty;

    }
}
