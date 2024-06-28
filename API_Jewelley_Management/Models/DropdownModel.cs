namespace API_Jewelley_Management.Models
{
    public class JewelleryTypeModel
    {
        public int JewelleryTypeID { get; set; }

        public string JewelleryTypeName { get; set; } = string.Empty;
    }

    public class SpecificationModel 
    { 
        public int JewelleryTypeWithSpecificationID { get; set; }

        public string? Name { get; set; } = string.Empty;

        public int? JewelleryTypeID { get; set; }
        public string? JewelleryTypeName { get; set; } = string.Empty;

        public List<int> MultipleTypeID { get; set; } = new List<int>();

    }

    public class JewelleryWithSpecification_Dropdown : JewelleryTypeModel
    {
        public List<string> Specifications { get; set; } = new List<string>();
    }
}
