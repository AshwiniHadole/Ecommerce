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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        protected readonly IEcomlogger logger;

        public ProductController(IProductRepository productRepository, IEcomlogger _logger)
        {
            this.productRepository = productRepository;
            this.logger = _logger;

        }
        #region GetAllProduct
        [HttpGet("GetAllProduct")]
        public IActionResult GetAll(int StoreId)
        {
            ResponseModel model = new ResponseModel();
            ActionResult result;
            try
            {
                IEnumerable<Product> product1 = new List<Product>();
                this.logger.LogInfo("Get all details by StoreId");
                product1 = this.productRepository.GetAllProduct(StoreId);
                model.Data = product1;
                model.statusCode = HttpStatusCode.OK.ToString();
                model.Message = "Get all data successfully";
                this.logger.LogInfo("All Products displayed");
                result = Ok(model);
            }
            catch (Exception ex)
            {
                model.Message = HttpStatusCode.OK.ToString();
                this.logger.LogInfo(string.Format(ex.Message));
                return BadRequest("Internal Server Error.");
            }
            return result;
        }
        #endregion

        #region GetProductById
        [HttpGet("GetProductById")]
        public IActionResult Get(int id)
        {
            ResponseModel model = new ResponseModel();

            ActionResult result;
            try
            {
                Product product1 = new Product();
                this.logger.LogInfo("Get all details of Product by Id.");
                product1 = this.productRepository.GetProductById(id);
                model.Data = product1;
                model.statusCode = HttpStatusCode.OK.ToString();
                model.Message = "Get all details of Product by Id";
                this.logger.LogInfo("All Products displayed");
                result = Ok(model);
            }
                catch (Exception ex)
            {
                model.statusCode = HttpStatusCode.InternalServerError.ToString();
                result = new StatusCodeResult(500);
                this.logger.LogError(string.Format(ex.Message));
                model.Message = "InternalServerError";
            }
            return result;
        }
        #endregion

        #region DeleteRecord
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int Id)
        {
            ResponseModel model = new ResponseModel();
            ActionResult result;
            try
            {
                this.logger.LogInfo("Delete Product by Id.");
                this.productRepository.DeleteProduct(Id);
                model.statusCode = HttpStatusCode.OK.ToString();
                model.Message = "Product deleted successfully";
                this.logger.LogInfo("Deleted Product By Id Successfully");
                result = Ok(model);
            }
            catch (Exception ex)
            {

                result = new StatusCodeResult(401);
                this.logger.LogError(string.Format(ex.Message));


            }
            return result;
        }
        #endregion

        #region UpdateProduct
        [HttpPut("UpdateProduct")]
        public IActionResult Put([FromBody] Product p)
        {
            ResponseModel model = new ResponseModel();
            ActionResult result;
            try
            {
                this.logger.LogInfo("Update Product Details.");
                this.productRepository.UpdateProduct(p);
                model.statusCode = HttpStatusCode.OK.ToString();
                model.Message = "Update Product Details Successfully";
                this.logger.LogInfo("All Products Details updated Successfully");
                result = Ok(model);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
                this.logger.LogError(string.Format(ex.Message));

            }
            return result;
        }
        #endregion

        #region Insert Data
        [HttpPost("CreateProduct")]
        public IActionResult Post([FromBody] Product p)
        {
            ResponseModel model = new ResponseModel(); 
            ActionResult result;
            try
            {
                this.logger.LogInfo("Insert New Product Details.");
                string abc;
                abc=this.productRepository.CreateProduct(p);
                model.statusCode = HttpStatusCode.OK.ToString();
                model.Message = "Insert New Product Details.";
                this.logger.LogInfo("All Products displayed Successfully");
                result = Ok(model);
            }
            catch (Exception ex)
            {
                result =StatusCode(500, ex.Message);
                this.logger.LogError(string.Format(ex.Message));
            }
            return result;
        }
        #endregion
    }

}
