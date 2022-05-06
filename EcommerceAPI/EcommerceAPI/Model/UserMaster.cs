using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Model
{
    public class UserMaster
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string LastName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(13, MinimumLength = 10)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int RoleId { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public DateTime DateOfActivation { get; set; }
        public DateTime DateOfPlanExpiry { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Active { get; set; }
        [Required]
        public string OTP { get; set; }
        public DateTime OTPTime { get; set; }
    }
}
