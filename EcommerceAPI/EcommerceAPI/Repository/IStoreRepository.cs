using EcommerceAPI.Model;
using System.Collections.Generic;

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