//using Microsoft.AspNetCore.Mvc; 
//namespace Hackthon.Controllers
//{

//    [Route("api/[controller]")]
//    [ApiController]

//    public class EmployeeController : Controller
//    {
//        [HttpGet]
//        public IActionResult Get()
//        {
//            EmployeeBAL bal = new EmployeeBAL();
//            List<EmployeeModel> emp = bal.API_Employee_SelectAll();

//            Console.WriteLine(emp);
//            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
//            if (emp.Count > 0 && emp != null)
//            {
//                response.Add("status", true);
//                response.Add("message", "Data Found.");
//                response.Add("data", emp);
//                return Ok(response);
//            }
//            else
//            {
//                response.Add("status", false);
//                response.Add("message", "Data not Found.");
//                response.Add("data", null);
//                return NotFound(response);
//            }
//        }

//        #region selectbyid
//        [HttpGet("{EmpID}")]
//        public IActionResult Get(int EmpID)
//        {
//            EmployeeBAL employeeBal = new EmployeeBAL();
//            EmployeeModel EmployeeModel = employeeBal.API_Employee_SelectByID(EmpID);
//            // Make the Response in Key Value Pair
//            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
//            if (EmployeeModel.EmpID != 0)
//            {
//                response.Add("status", true);
//                response.Add("message", "Data Found");
//                response.Add("data", EmployeeModel);
//                return Ok(response);
//            }
//            else
//            {
//                response.Add("status", false);
//                response.Add("message", "Data Not Found");
//                response.Add("data", null);
//                return NotFound(response);
//            }
//        }
//        #endregion

//        #region Delete

//        [HttpDelete("{EmpID}")]
//        public IActionResult Delete(int EmpID)
//        {
//            EmployeeBAL employeeBal = new EmployeeBAL();
//            bool IsSuccess = employeeBal.API_Employee_Delete(EmpID);
//            // Make the Response in Key Value Pair
//            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
//            if (IsSuccess)
//            {
//                response.Add("status", true);
//                response.Add("message", "Data delete successfully");

//                return Ok(response);
//            }
//            else
//            {
//                response.Add("status", false);
//                response.Add("message", "some error occur..!");

//                return NotFound(response);
//            }

//        }
//        #endregion

//        #region Insert
//        [HttpPost]
//        public IActionResult Post([FromForm] EmployeeModel EmployeeModel)
//        {
//            EmployeeBAL employeeBal = new EmployeeBAL();
//            bool IsSuccess = employeeBal.API_Employee_Insert(EmployeeModel);
//            // Make the Response in Key Value Pair
//            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
//            if (IsSuccess)
//            {
//                response.Add("status", true);
//                response.Add("message", "Data inserted successfully");

//                return Ok(response);
//            }
//            else
//            {
//                response.Add("status", false);
//                response.Add("message", "some error occur..!");

//                return NotFound(response);
//            }

//        }
//        #endregion

//        #region Update
//        [HttpPut("{EmpID}")]
//        public IActionResult Put(int EmpID, [FromForm] EmployeeModel EmployeeModel)
//        {
//            EmployeeBAL employeeBal = new EmployeeBAL();
//            EmployeeModel.EmpID = EmpID;
//            bool IsSuccess = employeeBal.API_Employee_Update(EmpID, EmployeeModel);

//            // Make the Response in Key Value Pair
//            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
//            if (IsSuccess)
//            {
//                response.Add("status", true);
//                response.Add("message", "Data updated successfully");

//                return Ok(response);
//            }
//            else
//            {
//                response.Add("status", false);
//                response.Add("message", "some error occures...!");

//                return NotFound(response);
//            }
//        }
//        #endregion
//    }

//}