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
        private StoreController createController(IStoreRepository storeRepository)
        {
            var controller = new StoreController(storeRepository);
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

            StoreController controller = this.createController(StoreRepository);

            ActionResult get = (ActionResult)controller.GetAllStore(33);
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

            StoreController controller = this.createController(StoreRepository);

            ActionResult get = (ActionResult)controller.GetStoreById(3);
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

            StoreController controller = this.createController(StoreRepository);

            ActionResult delete = (ActionResult)controller.DeleteStore(3);
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

            StoreController controller = this.createController(StoreRepository);
            
            ActionResult add = (ActionResult)controller.AddStore(store);
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

            StoreController controller = this.createController(StoreRepository);

            ActionResult update = (ActionResult)controller.UpdateStore(store);
        }
        #endregion
    }
}

