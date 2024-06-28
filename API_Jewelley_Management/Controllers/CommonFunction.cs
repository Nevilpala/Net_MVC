using Microsoft.AspNetCore.Mvc;

namespace API_Jewelley_Management.Controllers
{
    public class CommonFunction : Controller
    {
        #region Common_Data
        public IActionResult Common_Data(dynamic data)
        {
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (data != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");   
                response.Add("data", data);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region Common_SelectALl
        public IActionResult Common_SelectALl(dynamic list)
        {
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (list != null && list.Count > 0 )
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", list);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region Common_SelectByID 
        public IActionResult Common_SelectByID(dynamic? data = null)
        { 
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (data != null )
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", data);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region Common_Insert
        public IActionResult Common_Insert(bool IsSuccess)
        {  
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Inserted Successfully"); 
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Some error occur..!"); 
                return NotFound(response);
            }
        }
        #endregion

        #region Common_Update
        public IActionResult Common_Update(bool IsSuccess)
        {
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Updated Successfully");

                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Some error occur..!");

                return NotFound(response);
            }
        }
        #endregion 

        #region Common_Delete
        public IActionResult Common_Delete(bool IsSuccess)
        {
            // Make the Response in Key Value Pair
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Deleted Successfully");

                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Some error occur..!");

                return NotFound(response);
            }
        }
        #endregion

        
    }
}
