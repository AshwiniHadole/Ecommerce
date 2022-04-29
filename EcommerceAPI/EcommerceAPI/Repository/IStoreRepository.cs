using EcommerceAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Repository
{
  public  interface IStoreRepository
    {

        IEnumerable<Store> GetAllStore(int userid);
        public Store GetStoreById(int storeid);
        public void DeleteStoreById(int Id);
        public void InsertIntoStore(Store store);
        public void UpdateStoreById(Store store);


       
    }
}







