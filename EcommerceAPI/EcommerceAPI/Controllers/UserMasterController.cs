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

        public UserMasterController(IUserMaster _user)
        {
            this.user = _user;
        }
        #endregion

        #region Insert New User
        [HttpPost("InsertNewUser")]
        public IActionResult InsertNewUser(UserMaster add)
        {
            IActionResult result;
            try
            {
                string Newuserdata=this.user.InsertNewUser(add);
                result = Ok(Newuserdata);
            }
            catch (Exception ex)
            {
                result = new StatusCodeResult(500);
                return BadRequest(string.Format(ex.Message));
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
                IEnumerable<UserMaster> obj = this.user.GetUserByUserId(Id);
                result = Ok(obj);
            }
            catch (Exception ex)
            {
                result = new StatusCodeResult(500);
                return BadRequest(string.Format(ex.Message));
            }
            return result;
        }
        #endregion
    }
}
