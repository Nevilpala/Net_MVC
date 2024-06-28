using API_Jewelley_Management.BAL;
using API_Jewelley_Management.DAL;
using APIDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace API_Jewelley_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class AccountController : Controller
    {
        Account_BAL account_BAL = new Account_BAL();
        CommonFunction cf = new CommonFunction();

        private IConfiguration _config;

        public AccountController(IConfiguration configuration)
        {
            _config = configuration;

        }

            #region Login
            [HttpGet("{Username}/{Password}")]
            public IActionResult Login(string Username, string Password)
            {
                Dictionary<string, dynamic> res = new Dictionary<string, dynamic>();

                if (string.IsNullOrEmpty(Username))
                {
                    res.Add("status", false);
                    res.Add("msg", "Enter Username");
                    res.Add("data", null);
                    return NotFound(res);
                }
                else if (string.IsNullOrEmpty(Password))
                {
                    res.Add("status", false);
                    res.Add("msg", "Enter  Password");
                    res.Add("data", null);
                    return NotFound(res);
                }   
                else
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var SecToken = new JwtSecurityToken(
                         issuer: _config["Jwt:Issuer"],
                         audience: _config["Jwt:Audience"],
                         claims: null,
                         expires: DateTime.Now.AddMinutes(60),
                         //expires: DateTime.Now.AddMilliseconds(10000),
                         signingCredentials: credentials
                       );

                    var token = new JwtSecurityTokenHandler().WriteToken(SecToken);
                    AccountModel model = account_BAL.API_Login_Check(Username, Password);
                    if (model != null)
                    {
                        res.Add("status", true);
                        res.Add("token", token);
                        res.Add("msg", "Data Found");
                        res.Add("data", model);
                        return Ok(res);
                    }
                    else
                {
                    res.Add("status", false);
                    res.Add("token", null);
                    res.Add("msg", "Invalid Username Or Password");
                    res.Add("data", null);
                    return NotFound(res);

                }
            }

        }
        #endregion


        [HttpGet]
        [Route("AdminDashboard")]
        public IActionResult API_Admin_Dashboard()
        {
            Dictionary<string, int> dict = account_BAL.API_Admin_Dashboard();

            return cf.Common_Data(dict);

        }


    }
}
