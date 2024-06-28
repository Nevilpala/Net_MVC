using API_Jewelley_Management.DAL;
using API_Jewelley_Management.Models;

namespace API_Jewelley_Management.BAL
{
    public class Product_BAL
    {
        Product_DALBase dal = new Product_DALBase();

        #region API_Product_SelectALL
        public List<ProductModel> API_Product_SelectALL()
        {
            return dal.API_Product_SelectALL();
        }
        #endregion

        #region API_Product_SelectByID
        public ProductModel API_Product_SelectByID(int ID)
        {
            return dal.API_Product_SelectByID(ID);
        }
        #endregion

        #region API_Product_Insert
        public bool API_Product_Insert(ProductModel model)
        {
            return dal.API_Product_Insert(model);
        }
        #endregion

        #region API_Product_Update
        public bool API_Product_Update(ProductModel model)
        {
            return dal.API_Product_Update(model);
        }
        #endregion

        #region API_Product_Delete
        public bool API_Product_Delete(int ID)
        {
            return dal.API_Product_Delete(ID);
        }
        #endregion
         
        public List<ProductModel> API_Product_Filter(ProductFilterOption options)
        {
            var filteredProducts = dal.API_Product_SelectALL().AsQueryable();
            
            // Filter by multiple Category IDs
            if (options.CategoryIds != null && options.CategoryIds.Any() && !options.CategoryIds.Contains(0))
                filteredProducts = filteredProducts.Where(p =>  options.CategoryIds.Contains(p.CategoryID.Value));

            // Filter by multiple SubCategory IDs
            if (options.SubCategoryIds != null && options.SubCategoryIds.Any() && !options.SubCategoryIds.Contains(0))
                filteredProducts = filteredProducts.Where(p => options.SubCategoryIds.Contains(p.SubCategoryID.Value));

            if (options.MinPrice.HasValue)
                filteredProducts = filteredProducts.Where(p => p.Price >= options.MinPrice.Value);

            if (options.MaxPrice.HasValue)
                filteredProducts = filteredProducts.Where(p => p.Price <= options.MaxPrice.Value);

            if (options.MinQuantity.HasValue)
                filteredProducts = filteredProducts.Where(p => p.Quantity >= options.MinQuantity.Value);

            if (options.MinRating.HasValue)
                filteredProducts = filteredProducts.Where(p => p.Rating >= options.MinRating.Value);

            if (!string.IsNullOrEmpty(options.SearchQuery))
                filteredProducts = filteredProducts.Where(p => p.ProductName.Contains(options.SearchQuery) || p.Description.Contains(options.SearchQuery));

            if (!string.IsNullOrEmpty(options.SortBy))
            {
                switch (options.SortBy)
                {
                    case "Name Ascen":
                        filteredProducts = filteredProducts.OrderBy(x=>x.ProductName);
                        break;
                    case "Name Decen":
                        filteredProducts = filteredProducts.OrderByDescending(x => x.ProductName);
                        break;
                    case "Price Ascen":
                        filteredProducts = filteredProducts.OrderBy(x => x.SellPrice);
                        break;
                    case "Price Decen":
                        filteredProducts = filteredProducts.OrderByDescending(x => x.SellPrice);
                        break;
                    default:    
                        break;
                }
            }
            return filteredProducts.ToList();

        }
    }
}
