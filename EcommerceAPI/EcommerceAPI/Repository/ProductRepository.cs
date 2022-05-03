using Dapper;
using EcommerceAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EcommerceAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected readonly IConfiguration _config;
        public ProductRepository(IConfiguration config)
        {
            this._config = config;
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public IEnumerable<Product> GetAllProduct(int StoreId1)
        {
            using IDbConnection conn = new SqlConnection(this._config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
            {
                string sQuery = @"Select StoreId,CategoryId,Name,Description,ShowPrice,Price,FavNote,Active FROM Product Where StoreId=@StoreId";
                return (IEnumerable<Product>)conn.Query<Product>(sQuery, new { StoreId = StoreId1 });
            }
        }

        public Product GetProductById(int id)
        {
            using IDbConnection conn = new SqlConnection(this._config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
            {
                string sQuery = @"Select * From Product Where Id=@Id";
                return conn.Query<Product>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void  DeleteProduct(int Id)
        {
            using IDbConnection conn = new SqlConnection(this._config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
            {
                conn.Execute("Update Product Set Active=0 Where Id=@Id", new { Id = Id });
            }
        }

        public void UpdateProduct(Product p)
        {
            using IDbConnection conn = new SqlConnection(this._config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
            {
                string sQuery = @"UPDATE Product SET  StoreId =@StoreId,CategoryId=@CategoryId, Name=@Name,Description=@Description,ShowPrice=@ShowPrice,Price =@Price,FavNote=@FavNote,Active =@Active Where Id=@Id";
                conn.Execute(sQuery, p);
            }
        }
        public bool CheckProduct(string Name)
        {
            Product userdata = new Product();
            using IDbConnection conn = new SqlConnection(this._config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
            {
                userdata = conn.Query<Product>("SELECT * FROM Product WHERE Name=@Name  And Active=1", new { Name = Name }).FirstOrDefault();
            }
            if (userdata != null)
            {
                return true;
            }
            
            else
            {
                return false;
            }
        }
        public string CreateProduct(Product p)
        {
            string abc = "";
            using IDbConnection conn = new SqlConnection(this._config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
            {
                if (CheckProduct(p.Name))
                {
                    abc = "Name already exist ";
                }
                else
                {
                    conn.Execute(@"INSERT INTO Product Values (@StoreId,@CategoryId,@Name,@Description,@ShowPrice,@Price,@FavNote,@CreatedOn,@CreatedBy,@Active)", new
                    {
                        StoreId = p.StoreId,
                        CategoryId = p.CategoryId,
                        Name = p.Name,
                        Description = p.Description,
                        ShowPrice = p.ShowPrice,
                        Price = p.Price,
                        FavNote = p.FavNote,
                        CreatedOn = System.DateTime.Now,
                        CreatedBy = p.CreatedBy,
                        Active = p.Active,
                    });
                    abc = "Data Inserted Successfully";
                }
            }
            return abc;
        }

      
    }
}

