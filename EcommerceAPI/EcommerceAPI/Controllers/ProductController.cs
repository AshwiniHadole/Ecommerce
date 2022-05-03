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
            ActionResult result;
            try
            {
                this.logger.LogInfo("Get all details by StoreId");
                IEnumerable<Product> product1 = new List<Product>();
                product1 = this.productRepository.GetAllProduct(StoreId);
                this.logger.LogInfo("All Products displayed");
                result = Ok(product1);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }
            return result;
        }
        #endregion

        #region GetProductById
        [HttpGet("GetProductById")]
        public IActionResult Get(int id)
        {
            ActionResult result;

            try
            {
                Product product1 = new Product();
                product1 = this.productRepository.GetProductById(id);
                result = Ok(product1);
            }
                catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }
            return result;
        }
        #endregion

        #region DeleteRecord
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int Id)
        {
            ActionResult result;
            try
            {
                this.productRepository.DeleteProduct(Id);
                result = new StatusCodeResult(200);
            }
            catch (Exception)
            {
                result = new StatusCodeResult(401);
            }
            return result;
        }
        #endregion

        #region UpdateProduct
        [HttpPut("UpdateProduct")]
        public IActionResult Put([FromBody] Product p)
        {
            ActionResult result;
            try
            {
                this.productRepository.UpdateProduct(p);
                result = Ok(p);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message);
            }
            return result;
        }
        #endregion

        #region Insert Data
        [HttpPost("CreateProduct")]
        public IActionResult Post([FromBody] Product p)
        {
            ActionResult result;
            try
            {
                string abc;
               abc=this.productRepository.CreateProduct(p);
                result = Ok(abc);
            }
            catch (Exception ex)
            {
                result =StatusCode(500, ex.Message);
            }
            return result;
        }
        #endregion
    }

}
