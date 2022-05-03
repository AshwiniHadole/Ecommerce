using Dapper;
using EcommerceAPI.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Repository
{
    public class UserMasterRepository : IUserMaster
    {
        #region Configuration
        private readonly IConfiguration configuration;
        public UserMasterRepository(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }
        #endregion

        #region InsertNewUser
        public string InsertNewUser(UserMaster add)
        {
            string Result = "";
            UserMaster newuser = new UserMaster();
            if (CheckUsername(add.UserName)==1)
            {
                Result = "UserName already exists.";
            }
            else
                using (IDbConnection con = new SqlConnection(this.configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                {
                con.Execute("INSERT INTO TblUserMaster(FirstName,LastName,UserName,Email,PhoneNumber,Password,RoleId,DateOfRegistration,DateOfActivation,DateOfPlanExpiry,CreatedOn,Active) VALUES (@FirstName,@LastName,@UserName,@Email,@PhoneNumber,@Password,@RoleId,@DateOfRegistration,@DateOfActivation,@DateOfPlanExpiry,@CreatedOn,@Active)", new
                    {
                        FirstName = add.FirstName,
                        LastName = add.LastName,
                        UserName = add.UserName,
                        Email = add.Email,
                        PhoneNumber = add.PhoneNumber,
                        Password = add.Password,
                        RoleId = add.RoleId,
                        DateOfRegistration = System.DateTime.Now,
                        DateOfActivation = System.DateTime.Now,
                        DateOfPlanExpiry = System.DateTime.Now.AddMonths(1),
                        CreatedOn = add.CreatedOn,
                        Active = add.Active
                    });
                    Result = "User Inserted Successfully.";
                };
            return(Result);
        }
        #endregion

        #region GetUserByUserId
        public IEnumerable<UserMaster> GetUserByUserId(int Id)
        {
            IEnumerable<UserMaster> obj;
            using (IDbConnection con = new SqlConnection(this.configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                obj = con.Query<UserMaster>("SELECT * FROM TblUserMaster WHERE UserId=@UserId", new
                {
                    UserId = Id
                });
            return obj;
        }
        #endregion

        #region CheckUsername
        public int CheckUsername(string UserName)
        {
            UserMaster userdata = new UserMaster();
            using (IDbConnection con = new SqlConnection(this.configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
            {
                userdata = con.Query<UserMaster>("SELECT * FROM TblUserMaster WHERE UserName=@UserName  And Active=1", new { UserName = UserName }).FirstOrDefault();
            }
            if (userdata != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
