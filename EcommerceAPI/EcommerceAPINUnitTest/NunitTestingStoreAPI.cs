using EcommerceAPI.Controllers;
using EcommerceAPI.Model;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace UserMasterNUnitTest
{
    class NunitTestingStoreAPI
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
        private StoreController createController(IStoreRepository storeRepository, IEcomlogger _logger)
        {
            var controller = new StoreController(storeRepository, _logger);
            return controller;
        }
        #endregion
        #region Testcases
        [Test]
        public void GetAllStore()
        {
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            IStoreRepository StoreRepository = new StoreRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();

            StoreController controller = this.createController(StoreRepository, EcomLoggerRepository);

            ActionResult result = (ActionResult)controller.GetAllStore(1001);
            Assert.IsNotNull(result);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode ,200);
            Assert.AreEqual("Get all store successfully", ((EcommerceAPI.Model.ResponseModel)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value).ResponseMessage);
        }
        #endregion
        #region Testcases
        [Test]
        public void GetStoreById()
        {
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            IStoreRepository StoreRepository = new StoreRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();

            StoreController controller = this.createController(StoreRepository, EcomLoggerRepository);

            ActionResult result = (ActionResult)controller.GetStoreById(3);
       
            Assert.IsNotNull(result);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.AreEqual("Get store by Id successfully",((EcommerceAPI.Model.ResponseModel)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value).Message);
        }
        #endregion
        #region Testcases
        [Test]
        public void DeleteStore()
        {
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            IStoreRepository StoreRepository = new StoreRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();

            StoreController controller = this.createController(StoreRepository, EcomLoggerRepository);

            ActionResult result = (ActionResult)controller.DeleteStore(3);
            Assert.IsNotNull(result);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.AreEqual("Delete store successfully", ((EcommerceAPI.Model.ResponseModel)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value).Message);

        }
        #endregion
        #region Testcases
        [Test]
        public void CreateStore()
        {
            Store store = new Store()
            {
                StoreId=1,
                UserId = 1001,
                Name = "Aarati",
                TagLine = "BestStore",
                Theme = "Best",
                BackGroundImage = "Image",
                SupportsMultipleLang = true,
                StoreRoute = "Route",
                CreatedOn = System.DateTime.Now,
                CreatedBy = "Rani",
                Active = true,
            };
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            IStoreRepository StoreRepository = new StoreRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();

            StoreController controller = this.createController(StoreRepository, EcomLoggerRepository);
            
            ActionResult result = (ActionResult)controller.AddStore(store);
            Assert.IsNotNull(result);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.AreEqual("Store Data inserted successfully", ((EcommerceAPI.Model.ResponseModel)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value).Message);
        }
        #endregion
        #region Testcases
        [Test]
        public void UpdateStore()
        {
            Store store = new Store()
            {
                StoreId = 1,
                UserId = 1001,
                Name = "Pooja",
                TagLine = "BestStore",
                Theme = "Best",
                BackGroundImage = "Image",
                SupportsMultipleLang = true,
                StoreRoute = "Route",
                CreatedOn = System.DateTime.Now,
                CreatedBy = "Rani",
                Active = true,
            };
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            IStoreRepository StoreRepository = new StoreRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();

            StoreController controller = this.createController(StoreRepository, EcomLoggerRepository);

            ActionResult result = (ActionResult)controller.UpdateStore(store);
            Assert.IsNotNull(result);
            Assert.AreEqual(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, 200);
            Assert.AreEqual("Store detail updated successfully", ((EcommerceAPI.Model.ResponseModel)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value).Message);
        }
        #endregion
    }
}

