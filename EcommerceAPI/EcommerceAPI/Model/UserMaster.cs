using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Model
{
    public class UserMaster
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public DateTime DateOfActivation { get; set; }
        public DateTime DateOfPlanExpiry { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Active { get; set; }
        public string OTP { get; set; }
        public DateTime OTPTime { get; set; }
    }
}
