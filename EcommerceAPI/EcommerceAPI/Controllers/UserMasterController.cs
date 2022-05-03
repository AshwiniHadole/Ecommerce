using EcommerceAPI.Model;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                this.logger.LogInfo("Insert New User Details.");
                string Newuserdata=this.user.InsertNewUser(add);
                this.logger.LogInfo("New User Details Inserted.");
                result = Ok(Newuserdata);
            }
            catch (Exception ex)
            {
                result = new StatusCodeResult(500);
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
            try
            {
                this.logger.LogInfo("Get all details by UserId");
                IEnumerable<UserMaster> obj = this.user.GetUserByUserId(Id);
                this.logger.LogInfo("All data displayed");
                result = Ok(obj);
            }
            catch (Exception ex)
            {
                result = new StatusCodeResult(500);
                this.logger.LogError(string.Format(ex.Message));
                return BadRequest("Internal Server Error.");
            }
            return result;
        }
        #endregion
    }
}
