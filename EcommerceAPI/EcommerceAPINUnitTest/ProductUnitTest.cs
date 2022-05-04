using EcommerceAPI.Controllers;
using EcommerceAPI.Model;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace Testproduct
{
    public class ProductTest
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
        private ProductController createController(IProductRepository productRepository, IEcomlogger _logger)
        {
            ProductController controller = new ProductController(productRepository, _logger);
            return controller;
        }
        #endregion


        #region Testcases
        [Test]
        public void CreateProduct()
        {
            Product product = new Product()
            {
                Id = 1,
                StoreId = 1,
                CategoryId = 1,
                Name = "Manisha",
                Description = "Test",
                ShowPrice = true,
                Price = 1,
                FavNote = "Nice",
                CreatedOn = DateTime.Now,
                CreatedBy = "Akanksha",
                Active = true,
            };

            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            IProductRepository ProductRepository = new ProductRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();


            ProductController controller = this.createController(ProductRepository, EcomLoggerRepository);

            ActionResult blomodel = (ActionResult)controller.Post(product);
        }
       


        [Test]
        public void GetProductById()
        {
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();



            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();



            IProductRepository ProductRepository = new ProductRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();


            ProductController controller = this.createController(ProductRepository, EcomLoggerRepository);

            ActionResult blomodel = (ActionResult)controller.Get(9);
        }


        [Test]
        public void DeleteProduct()
        {
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();



            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();


            IProductRepository ProductRepository = new ProductRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();


            ProductController controller = this.createController(ProductRepository, EcomLoggerRepository);

            ActionResult blomodel = (ActionResult)controller.Delete(10);

        }


        [Test]
        public void UpdateProduct()
        {
            Product product = new Product()
            {
                Id = 62,
                StoreId = 1010,
                CategoryId = 1020,
                Name = "Vivo mobile",
                Description = "Vivo Test",
                ShowPrice = true,
                Price = 22250,
                FavNote = "Good Quality",
                Active = true,
            };

            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var memoryCache = serviceProvider.GetService<IMemoryCache>();


            IProductRepository ProductRepository = new ProductRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();


            ProductController controller = this.createController(ProductRepository, EcomLoggerRepository);

            ActionResult result = (ActionResult)controller.Put(product);

            Assert.IsNotNull(result);


        }


        [Test]
        public void GetAllProduct()
        {
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();



            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();


            IProductRepository ProductRepository = new ProductRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();


            ProductController controller = this.createController(ProductRepository, EcomLoggerRepository);

            ActionResult blomodel = (ActionResult)controller.GetAll(1043);
            

        }
        #endregion
    }

}
