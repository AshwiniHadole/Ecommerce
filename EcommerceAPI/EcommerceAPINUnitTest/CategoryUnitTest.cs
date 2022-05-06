using EcommerceAPI.Controllers;
using EcommerceAPI.Model;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace EcommerceAPINUnitTest
{
    class CategoryUnitTest
    {
        #region Configuration
        private IConfiguration initConfiguration()
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("./appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            return configuration;
        }
        #endregion

        #region Controller
        private CategoryController createController(ICategory _category, IEcomlogger _logger)
        {
            CategoryController controller = new CategoryController(_category, _logger);
            return controller;
        }
        #endregion

        #region
        [Test]
        public void GetCategoryById()
        {
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            ICategory InventoryCategoryRepository = new CategoryRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();

            CategoryController controller = this.createController(InventoryCategoryRepository, EcomLoggerRepository);

            ActionResult result = (ActionResult)controller.GetCategoryById(3); 
            
            Assert.IsNotNull(result);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.AreEqual("GetCategoryById executed successfully.", ((EcommerceAPI.Model.ResponseModel)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value).Message);
        }

        [Test]
        public void GetCategoryByStoreId()
        {
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            ICategory InventoryCategoryRepository = new CategoryRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();

            CategoryController controller = this.createController(InventoryCategoryRepository, EcomLoggerRepository);

            ActionResult result = (ActionResult)controller.GetCategoryByStoreId(12);
            Assert.IsNotNull(result);
            Assert.AreEqual("GetCategoryByStoreId executed successfully.", ((EcommerceAPI.Model.ResponseModel)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value).Message);
            Assert.AreEqual("OK",((EcommerceAPI.Model.ResponseModel)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value).statusCode);

        }

        [Test]
        public void DeleteCategoryById()
        {
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            ICategory InventoryCategoryRepository = new CategoryRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();

            CategoryController controller = this.createController(InventoryCategoryRepository, EcomLoggerRepository);

            ActionResult result = (ActionResult)controller.DeleteCategoryById(12);
            Assert.IsNotNull(result);
            Assert.AreEqual("Category Deleted Successfully.", ((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value);
            Assert.AreEqual(200, ((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode);
        }

        [Test]
        public void UpdateCategoryById()
        {
            Category inventorycategory = new Category()
            {
                Id = 21,
                StoreId = "1044",
                Name = "Snacks",
                CreatedOn = DateTime.Now,
                CreatedBy = "Pankaj",
                Active = 1,
            };
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            ICategory InventoryCategoryRepository = new CategoryRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();

            CategoryController controller = this.createController(InventoryCategoryRepository, EcomLoggerRepository);

            ActionResult result = (ActionResult)controller.UpdateCategoryById(inventorycategory);
            Assert.IsNotNull(result);
            Assert.IsNotNull(inventorycategory.CreatedOn);
            Assert.AreEqual("UpdateCategoryById executed successfully.",((EcommerceAPI.Model.ResponseModel)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value).Message);
        }

        [Test]
        public void InsertNewCategory()
        {
            Category inventorycategory = new Category()
            {
                Id = 25,
                StoreId = "1045",
                Name = "Furniture",
                CreatedOn = DateTime.Now,
                CreatedBy = "Arohi",
                Active = 1,
            };
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            ICategory InventoryCategoryRepository = new CategoryRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();

            CategoryController controller = this.createController(InventoryCategoryRepository, EcomLoggerRepository);

            ActionResult result = (ActionResult)controller.InsertNewCategory(inventorycategory);
            Assert.IsNotNull(result);
            Assert.IsTrue(inventorycategory.Id > 0);
            Assert.IsNotNull(inventorycategory.CreatedOn);
        }
        #endregion
    }
}
