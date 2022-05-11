using EcommerceAPI.Model;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

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
            ResponseModel model = new ResponseModel();
            IActionResult result;
            try
            {
                IEnumerable<Store> stores = new List<Store>();
                this.logger.LogInfo("Called all store by user Id");
                stores = this.storeRepository.GetAllStore(userid);
                model.Data = stores;
                model.statusCode = HttpStatusCode.OK.ToString();
                model.Message = "Get all store successfully";
                this.logger.LogInfo("Get all store by user Id");
                result = Ok(model);
            }
            catch (Exception ex)
            {
                model.statusCode = HttpStatusCode.InternalServerError.ToString();
                model.Message = "InternalServerError";
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
            ResponseModel model = new ResponseModel();
            IActionResult result;
            try
            {
                Store obj = new Store();
                this.logger.LogInfo("Called store by store Id");
                obj = this.storeRepository.GetStoreById(storeid);
                model.Data = obj;
                model.statusCode = HttpStatusCode.OK.ToString();
                model.Message = "Get store by Id successfully";
                this.logger.LogInfo("Get all store by store Id");
                result = Ok(model);
            }
            catch (Exception ex)
            {
                model.statusCode = HttpStatusCode.InternalServerError.ToString();
                model.Message = "InternalServerError";
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
            ResponseModel model = new ResponseModel();
            IActionResult result;
            try
            {
                this.logger.LogInfo("Called Delete store by Id");
                this.storeRepository.DeleteStoreById(Id);
                model.statusCode = HttpStatusCode.OK.ToString();
                model.Message = "Delete store successfully";
                this.logger.LogInfo("Delete store by Id");
                result = Ok(model);
            }
            catch (Exception ex)
            {
                model.statusCode = HttpStatusCode.InternalServerError.ToString();
                model.Message = "InternalServerError";
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
            ResponseModel model = new ResponseModel();
            IActionResult result;
            try
            {
                string A;
                this.logger.LogInfo("Insert New store Details.");
                A = this.storeRepository.CreateStore(store);
                model.Data = A;
                model.statusCode = HttpStatusCode.OK.ToString();
                model.Message = "Store Data inserted successfully";
                this.logger.LogInfo("New store Details Inserted successfully.");
                result = Ok(model);
            }
            catch (Exception ex)
            {
                model.statusCode = HttpStatusCode.InternalServerError.ToString();
                model.Message = "InternalServerError";
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
            ResponseModel model = new ResponseModel();
            IActionResult result;
            try
            {
                this.logger.LogInfo("Update store Details.");
                this.storeRepository.UpdateStoreById(store);
                model.statusCode = HttpStatusCode.OK.ToString();
                model.Message = "Store detail updated successfully";
                this.logger.LogInfo("Store detail updated successfully.");
                result = Ok(model);
            }
            catch (Exception ex)
            {
                model.statusCode = HttpStatusCode.InternalServerError.ToString();
                model.Message = "InternalServerError";
                result = new StatusCodeResult(500);
                this.logger.LogError(string.Format(ex.Message));
                return BadRequest("Internal Server Error.");
            }
            return result;
        }
        #endregion
        [HttpGet("GetStores")]
        public IActionResult GetStores()
        {
            ResponseModel model = new ResponseModel();
            IActionResult result;
            try
            {
                IEnumerable<Store> stlist = new List<Store>();
                this.logger.LogInfo("Called store ");
                stlist = this.storeRepository.Getstores();
                model.Data = stlist;
                model.statusCode = HttpStatusCode.OK.ToString();
                model.Message = "Get All store successfully";
                this.logger.LogInfo("Get all store ");
                result = Ok(model);
            }
            catch (Exception ex)
            {
                model.statusCode = HttpStatusCode.InternalServerError.ToString();
                model.Message = "InternalServerError";
                result = new StatusCodeResult(500);
                this.logger.LogError(string.Format(ex.Message));
                return BadRequest("Internal Server Error.");
            }
            return result;
        }
    }
}
