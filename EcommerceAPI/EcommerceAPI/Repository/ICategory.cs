using EcommerceAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Repository
{
    public interface ICategory
    {
        IEnumerable<Category> GetAllCategory();
        IEnumerable<Category> GetCategoryById(int Id);
        IEnumerable<Category> GetCategoryByStoreId(int StoreId);
        void DeleteCategoryById(int Id);
        string UpdateCategoryById(Category set);
        string InsertNewCategory(Category add);
    }
}
