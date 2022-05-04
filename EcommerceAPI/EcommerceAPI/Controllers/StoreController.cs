using EcommerceAPI.Model;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository storeRepository;
        protected readonly IEcomlogger logger;
        public StoreController( IStoreRepository _storeRepository, IEcomlogger _logger)
        {
            this.storeRepository = _storeRepository;
            this.logger = _logger;
        }
        #region GetAllStore
        //Get all store by using userid.
        [HttpGet("GetAllStore")]
        public IActionResult GetAllStore(int userid)
        {
            IActionResult result;
            try
            {
                IEnumerable<Store> stores = new List<Store>();
                this.logger.LogInfo("Called all store by user Id");
                stores = this.storeRepository.GetAllStore(userid);
                this.logger.LogInfo("Get all store by user Id");
                result = Ok(stores);
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

        #region GetStore
        //Get store by using storeid.
        [HttpGet("GetStoreById")]
        public IActionResult GetStoreById(int storeid)
        {
            IActionResult result;
            try
            {
                Store obj = new Store();
                this.logger.LogInfo("Called store by store Id");
                obj = this.storeRepository.GetStoreById(storeid);
                this.logger.LogInfo("Get all store by store Id");
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

        #region DeleteStore
        //Delete store by using userid.
        [HttpDelete("DeleteStore")]
        public IActionResult DeleteStore(int Id)
        {
            IActionResult result;
            try
            {
                this.logger.LogInfo("Called Delete store by Id");
                this.storeRepository.DeleteStoreById(Id);
                this.logger.LogInfo("Delete store by Id");
                result = new StatusCodeResult(200);
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

        #region AddStore
        //Insert store detail in store.
        [HttpPost("AddStore")]
        public IActionResult AddStore([FromBody]Store store)
        {
            IActionResult result;
            try
            {
                string A;
                this.logger.LogInfo("Insert New store Details.");
                A = this.storeRepository.CreateStore(store);
                this.logger.LogInfo("New store Details Inserted successfully.");
                result = Ok(A);
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

        #region Updatestore
        //Update store detail.
        [HttpPut("UpdateStore")]
        public IActionResult UpdateStore([FromBody] Store store)
        {
            IActionResult result;
            try
            {
                this.logger.LogInfo("Update store Details.");
                this.storeRepository.UpdateStoreById(store);
                this.logger.LogInfo("Store detail updated successfully.");
                result = new StatusCodeResult(200);
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
