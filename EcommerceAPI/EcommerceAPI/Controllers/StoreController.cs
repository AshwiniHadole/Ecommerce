using EcommerceAPI.Model;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IStoreRepository _storeRepository;
        public StoreController(IConfiguration config, IStoreRepository storeRepository)
        {
            this._config = config;
            this._storeRepository = storeRepository;
        }
        #region GetAllStore
        //Get all store by using userid.
        [HttpGet("GetAllStore")]
        public IActionResult GetAllStore(int userid)
        {
            IActionResult result;
            IEnumerable<Store> stores = new List<Store>();
            stores = this._storeRepository.GetAllStore(userid);
            result = Ok(stores);
            return result;
        }
        #endregion

        #region GetStore
        //Get store by using storeid.
        [HttpGet("GetStoreById")]
        public IActionResult GetStoreById(int storeid)
        {
            IActionResult result;
            Store obj = new Store();
            obj = this._storeRepository.GetStoreById(storeid);
            result = Ok(obj);
            return result;
        }
        #endregion

        #region DeleteStore
        //Delete store by using userid.
        [HttpDelete("DeleteStore")]
        public IActionResult DeleteStore(int Id)
        {
            IActionResult result;
            this._storeRepository.DeleteStoreById(Id);
            result = new StatusCodeResult(200);
            return result;
        }
        #endregion

        #region AddStore
        //Insert store detail in store.
        [HttpPost("AddStore")]
        public IActionResult AddStore([FromBody]Store store)
        {           
            IActionResult result;
            string A;
            A= this._storeRepository.CreateStore( store);
            result = Ok(A);
            return result;
        }
        #endregion

        #region Updatestore
        //Update store detail.
        [HttpPut("UpdateStore")]
        public IActionResult UpdateStore([FromBody] Store store)
        {
            IActionResult result;
            this._storeRepository.UpdateStoreById(store);
            result = new StatusCodeResult(200);
            return result;
        }
       #endregion
    }
}
