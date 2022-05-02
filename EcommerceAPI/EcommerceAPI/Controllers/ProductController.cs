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
        protected readonly IConfiguration _config;
        public ProductController(IProductRepository productRepository, IConfiguration _config)
        {
            this.productRepository = productRepository;
            this._config = _config;
        }
        #region GetAllProduct
        [HttpGet("GetAllProduct")]
        public IActionResult GetAll(int StoreId)
        {
            ActionResult result;
            try
            {
                IEnumerable<Product> product1 = new List<Product>();
                product1 = this.productRepository.GetAllProduct(StoreId);
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
            catch (Exception ex)
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
                result = Ok();
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
