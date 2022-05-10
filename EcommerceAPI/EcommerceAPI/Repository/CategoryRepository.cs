using Dapper;
using EcommerceAPI.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly IConfiguration configuration;
        public CategoryRepository (IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }
        public IEnumerable<Category> GetAllCategory()
        {
            IEnumerable<Category> newcategory;
            using (IDbConnection con = new SqlConnection(this.configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                newcategory = con.Query<Category>("SELECT Id,StoreId,Name,CreatedOn,CreatedBy,Active FROM TblInventoryCategory WHERE Active=1");
            return newcategory;
        }
        public IEnumerable<Category> GetCategoryById(int Id)
        {
            IEnumerable<Category> category;
            using (IDbConnection con = new SqlConnection(this.configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                category = con.Query<Category>("SELECT Id,StoreId,Name,CreatedOn,CreatedBy,Active FROM TblInventoryCategory WHERE Id=@Id AND Active=1", new
                {
                    Id=Id
                }
                    );
            return category;
        }

        public IEnumerable<Category> GetCategoryByStoreId(int StoreId)
        {
            IEnumerable<Category> _category;
            using (IDbConnection con = new SqlConnection(this.configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                _category = con.Query<Category>("SELECT Id,StoreId,Name,CreatedOn,CreatedBy,Active FROM TblInventoryCategory WHERE StoreId=@StoreId AND Active=1", new
                {
                    StoreId = StoreId
                }
                    );
            return _category;
        }

        public void DeleteCategoryById(int Id)
        {
            using (IDbConnection con = new SqlConnection(this.configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                con.Execute(@"UPDATE TblInventoryCategory SET Active=0 WHERE Id=@Id",new
                {
                    Id=Id
                });
        }

        public string UpdateCategoryById(Category set)
        {
            string Result = "";
            using (IDbConnection con = new SqlConnection(this.configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                con.Execute(@"UPDATE TblInventoryCategory SET StoreId=@StoreId,Name=@Name,CreatedOn=@CreatedOn,CreatedBy=@CreatedBy,Active=@Active where Id=@Id", new
                {
                    Id=set.Id,
                    StoreId = set.StoreId,
                    Name = set.Name,
                    CreatedOn = DateTime.Now,
                    CreatedBy = set.CreatedBy,
                    Active = set.Active
                });
            Result = "Category Updated Successfully.";
            return (Result);
        }

        public string InsertNewCategory(Category add)
        {
            string result = "";
            Category NewInventoryCategory = new Category();
            if (CheckName(add.Name) == 1)
            {
                result = "Name already exists.";
            }
            else
                using (IDbConnection con = new SqlConnection(this.configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
                {
                    con.Execute(@"INSERT INTO TblInventoryCategory VALUES (@StoreId,@Name,@CreatedOn,@CreatedBy,@Active)", new
                    {
                        StoreId = add.StoreId,
                        Name = add.Name,
                        CreatedOn = DateTime.Now,
                        CreatedBy = add.CreatedBy,
                        Active = add.Active
                    });

                    result = "Category Inserted Successfully."; 
                };
            return (result);
        }

        public int CheckName(string Name)
        {
            Category NewCategory = new Category();
            using (IDbConnection con = new SqlConnection(this.configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value))
            {
                NewCategory = con.Query<Category>("SELECT Id,StoreId,Name,CreatedOn,CreatedBy,Active FROM TblInventoryCategory WHERE Name=@Name  And Active=1", new { Name = Name }).FirstOrDefault();
            }
            if (NewCategory != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
