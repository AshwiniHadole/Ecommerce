using EcommerceAPI.Model;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadProductImageController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        
        public UploadProductImageController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpPost]
        public IActionResult Upload([FromForm]Product product)
        {
            Product p= new Product ();
            p.Id = product.Id;
            p.Name = product.Name;
            p.Description = product.Description;
            p.Price = product.Price;
            p.StoreId=product.StoreId;
            p.CategoryId = product.CategoryId;
            p.ShowPrice = product.ShowPrice;
            p.FavNote = product.FavNote;
            p.CreatedOn = product.CreatedOn;
            p.CreatedBy = product.CreatedBy;
            p.Active = product.Active;
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
               
                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }
                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    string abc;
                    p.ImagePath = fullPath;
                    abc = this.productRepository.CreateProduct(p);
                }
                return Ok("All the files are successfully uploaded.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error while uploading Images");
            }
        }
    }
}
