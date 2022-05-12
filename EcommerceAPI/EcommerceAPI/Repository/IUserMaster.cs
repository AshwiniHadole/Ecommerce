using EcommerceAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Repository
{
    public interface IUserMaster
    {
        string InsertNewUser(UserMaster User);
        IEnumerable<UserMaster> GetUserByUserId(int Id);
    }
}
