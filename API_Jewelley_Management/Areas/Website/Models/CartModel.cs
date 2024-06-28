namespace API_Jewelley_Management.Areas.Website.Models
{
    public class CartModel
    {
        public int CartID { get; set; }
        public int ProductID { get; set; }

        public string? ProductCode { get; set; }

        public int UserID { get; set; } 
        public int Quantity { get; set; }


    }
}
