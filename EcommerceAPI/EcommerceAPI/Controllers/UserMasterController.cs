using EcommerceAPI.Model;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController : Controller
    {
        #region Configuration
        protected readonly IConfiguration _config;
        private readonly IUserMaster user;
        protected readonly IEcomlogger logger;

        public UserMasterController(IUserMaster _user,IEcomlogger _logger)
        {
            this.user = _user;
            this.logger = _logger;
        }
        #endregion

        #region Insert New User
        [HttpPost("InsertNewUser")]
        public IActionResult InsertNewUser(UserMaster add)
        {
            IActionResult result;
            ResponseModel res = new ResponseModel();
            try
            {
                this.logger.LogInfo("Insert New User Details.");
                string Newuserdata=this.user.InsertNewUser(add);
                res.Data = Newuserdata;
                res.Message = "GetCategoryById executed successfully.";
                res.statusCode = HttpStatusCode.OK.ToString();
                this.logger.LogInfo("New User Details Inserted.");
                result = Ok(res);
            }
            catch (Exception ex)
            {
                res.statusCode = HttpStatusCode.OK.ToString();
                this.logger.LogError(string.Format(ex.Message));
                return BadRequest("Internal Server Error.");
            }
            return result;
        }
        #endregion

        #region GetUserByUserId
        [HttpGet("GetUserByUserId")]
        public IActionResult GetUserByUserId(int Id)
        {
            IActionResult result;
            ResponseModel res = new ResponseModel();
            try
            {
                this.logger.LogInfo("Get all details by UserId");
                IEnumerable<UserMaster> obj = this.user.GetUserByUserId(Id);
                res.Data = obj;
                res.Message = "GetCategoryById executed successfully.";
                res.statusCode = HttpStatusCode.OK.ToString();
                this.logger.LogInfo("All data displayed");
                result = Ok(res);
            }
            catch (Exception ex)
            {
                res.statusCode = HttpStatusCode.OK.ToString();
                this.logger.LogError(string.Format(ex.Message));
                return BadRequest("Internal Server Error.");
            }
            return result;
        }
        #endregion
    }
}
