using EcommerceAPI.Model;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        [HttpGet("GetAllCategory")]
        public IActionResult GetAllCategory()
        {
            IActionResult result;
            ResponseModel res = new ResponseModel();
            try
            {
                this.logger.LogInfo("Get All Categories.");
                IEnumerable<Category> newcategory = this.category.GetAllCategory();
                res.Data = newcategory;
                res.Message = "GetAllCategory executed successfully.";
                res.statusCode = HttpStatusCode.OK.ToString();
                this.logger.LogInfo("All Categories Displayed.");
                result = Ok(res);
            }
            catch (Exception ex)
            {
                res.statusCode = HttpStatusCode.BadRequest.ToString();
                this.logger.LogInfo(string.Format(ex.Message));
                return BadRequest("Internal Server Error");
            }
            return result;
        }
        [HttpGet("GetCategoryById")]
        public IActionResult GetCategoryById(int Id)
        {
            IActionResult result;
            ResponseModel res = new ResponseModel();
            try
            {
                this.logger.LogInfo("Get All Details by Id.");
                IEnumerable<Category> category = this.category.GetCategoryById(Id);
                res.Data = category;
                res.Message = "GetCategoryById executed successfully.";
                res.statusCode = HttpStatusCode.OK.ToString();
                this.logger.LogInfo("All Data Displayed.");
                result = Ok(res);
            }
            catch (Exception ex)
            {
                res.statusCode = HttpStatusCode.BadRequest.ToString();
                this.logger.LogInfo(string.Format(ex.Message));
                return BadRequest("Internal Server Error");
            }
            return result;
        }

        [HttpGet("GetCategoryByStoreId")]
        public IActionResult GetCategoryByStoreId(int StoreId)
        {
            IActionResult result;
            ResponseModel res = new ResponseModel();
            try
            {
                this.logger.LogInfo("Get All Details By StoreId.");
                IEnumerable<Category> _category = this.category.GetCategoryByStoreId(StoreId);
                res.Data = _category;
                res.Message = "GetCategoryByStoreId executed successfully.";
                res.statusCode = HttpStatusCode.OK.ToString();
                this.logger.LogInfo("All Data Displayed.");
                result = Ok(res);
            }
            catch (Exception ex)
            {
                res.statusCode = HttpStatusCode.OK.ToString();
                this.logger.LogInfo(string.Format(ex.Message));
                return BadRequest("Internal Server Error.");
            };
            return result;
        }

        [HttpDelete("DeleteCategoryById")]
        public IActionResult DeleteCategoryById(int Id)
        {
            IActionResult result;
            ResponseModel res = new ResponseModel();
            try
            {
                this.logger.LogInfo("Delete Category By Id.");
                this.category.DeleteCategoryById(Id);
                res.Message = "DeleteCategoryById executed successfully.";
                res.statusCode = HttpStatusCode.OK.ToString();
                this.logger.LogInfo("Category Deleted Successfully.");
                result = Ok("Category Deleted Successfully.");
            }
            catch (Exception ex)
            {
                res.statusCode = HttpStatusCode.OK.ToString();
                this.logger.LogInfo(string.Format(ex.Message));
                return BadRequest("Internal Server Error.");
            };
            return result;
        }

        [HttpPut("UpdateCategoryById")]
        public IActionResult UpdateCategoryById(Category set)
        {
            IActionResult result;
            ResponseModel res = new ResponseModel();
            try
            {
                this.logger.LogInfo("Update Category By Id.");
                string A = this.category.UpdateCategoryById(set);
                res.Data = A;
                res.Message = "UpdateCategoryById executed successfully.";
                res.statusCode = HttpStatusCode.OK.ToString();
                this.logger.LogInfo("Category Updated Successfully.");
                result = Ok(res);
            }
            catch (Exception ex)
            {
                res.statusCode = HttpStatusCode.OK.ToString();
                this.logger.LogInfo(string.Format(ex.Message));
                return BadRequest("Internal Server Error.");
            };
            return result;
        }

        [HttpPost("InsertNewCategory")]
        public IActionResult InsertNewCategory(Category add)
        {
            IActionResult result;
            ResponseModel res = new ResponseModel();
            try
            {
                this.logger.LogInfo("Insert Category.");
                string newcategory = this.category.InsertNewCategory(add);
                res.Data = newcategory;
                res.Message = "InsertNewCategory executed successfully.";
                res.statusCode = HttpStatusCode.OK.ToString();
                this.logger.LogInfo("Category Inserted Successfully.");
                result = Ok(res);
            }
            catch (Exception ex)
            {
                res.statusCode = HttpStatusCode.OK.ToString();
                this.logger.LogInfo(string.Format(ex.Message));
                return BadRequest("Internal Server Error.");
            };
            return result;
        }
    }
}
