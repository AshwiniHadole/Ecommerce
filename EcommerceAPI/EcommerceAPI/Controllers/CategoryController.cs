using EcommerceAPI.Model;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Controllers
{
    public class CategoryController : Controller
    {
        protected readonly IConfiguration _config;
        private readonly ICategory category;
        protected readonly IEcomlogger logger;
        public CategoryController(ICategory _category, IEcomlogger _logger)
        {
            this.category = _category;
            this.logger = _logger;
        }

        [HttpGet("GetCategoryById")]
        public IActionResult GetCategoryById(int Id)
        {
            IActionResult result;
            try
            {
                this.logger.LogInfo("Get All Details by Id.");
                IEnumerable<Category> ById = this.category.GetCategoryById(Id);
                this.logger.LogInfo("All Data Displayed.");
                result = Ok(ById);
            }
            catch (Exception ex)
            {
                result = new StatusCodeResult(500);
                this.logger.LogInfo(string.Format(ex.Message));
                return BadRequest("Internal Server Error");
            }
            return result;
        }

        [HttpGet("GetCategoryByStoreId")]
        public IActionResult GetCategoryByStoreId(int StoreId)
        {
            IActionResult result;
            try
            {
                this.logger.LogInfo("Get All Details By StoreId.");
                IEnumerable<Category> ByStoreId = this.category.GetCategoryByStoreId(StoreId);
                this.logger.LogInfo("All Data Displayed.");
                result = Ok(ByStoreId);
            }
            catch (Exception ex)
            {
                result = new StatusCodeResult(500);
                this.logger.LogInfo(string.Format(ex.Message));
                return BadRequest("Internal Server Error.");
            };
            return result;
        }

        [HttpDelete("DeleteCategoryById")]
        public IActionResult DeleteCategoryById(int Id)
        {
            IActionResult result;
            try
            {
                this.logger.LogInfo("Delete Category By Id.");
                this.category.DeleteCategoryById(Id);
                this.logger.LogInfo("Category Deleted Successfully.");
                result = Ok("Category Deleted Successfully.");
            }
            catch (Exception ex)
            {
                result = new StatusCodeResult(500);
                this.logger.LogInfo(string.Format(ex.Message));
                return BadRequest("Internal Server Error.");
            };
            return result;
        }

        [HttpPut("UpdateCategoryById")]
        public IActionResult UpdateCategoryById(Category set)
        {
            IActionResult result;
            try
            {
                this.logger.LogInfo("Update Category By Id.");
                string A = this.category.UpdateCategoryById(set);
                this.logger.LogInfo("Category Updated Successfully.");
                result = Ok(A);
            }
            catch (Exception ex)
            {
                result = new StatusCodeResult(500);
                this.logger.LogInfo(string.Format(ex.Message));
                return BadRequest("Internal Server Error.");
            };
            return result;
        }

        [HttpPost("InsertNewCategory")]
        public IActionResult InsertNewCategory(Category add)
        {
            IActionResult result;
            try
            {
                this.logger.LogInfo("Insert Category.");
                string newcategory = this.category.InsertNewCategory(add);
                this.logger.LogInfo("Category Inserted Successfully.");
                result = Ok(newcategory);
            }
            catch (Exception ex)
            {
                result = new StatusCodeResult(500);
                this.logger.LogInfo(string.Format(ex.Message));
                return BadRequest("Internal Server Error.");
            };
            return result;
        }
    }
}
