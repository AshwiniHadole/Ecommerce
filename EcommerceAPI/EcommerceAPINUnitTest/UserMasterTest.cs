using EcommerceAPI.Controllers;
using EcommerceAPI.Model;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace UserMasterNUnitTest
{
    public class UserMasterTest
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
        private UserMasterController createController(IUserMaster _user, IEcomlogger _logger)
        {
            UserMasterController controller = new UserMasterController(_user, _logger);
            return controller;
        }
        #endregion

        #region Testcases
        [Test]
        public void InsertNewUser()
        {
            UserMaster usermaster = new UserMaster()
            {
                UserId = 99,
                FirstName = "Mahesh",
                LastName = "Rathod",
                UserName = "RMahesh",
                Email = "mahesh9881@gmail.com",
                PhoneNumber = "9865241370",
                Password = "RakeshS@456",
                RoleId = 10,
                DateOfRegistration = DateTime.Now,
                DateOfActivation = DateTime.Now,
                DateOfPlanExpiry = DateTime.Now,
                CreatedOn = DateTime.Now,
                Active = 1,
                OTP = null,
                OTPTime = DateTime.Now,
            };

            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            IUserMaster UserMasterRepository = new UserMasterRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();

            UserMasterController controller = this.createController(UserMasterRepository, EcomLoggerRepository);

            ActionResult result = (ActionResult)controller.InsertNewUser(usermaster);
            Assert.IsNotNull(result);
            Assert.IsTrue(usermaster.UserId > 0);
            Assert.IsNotNull(usermaster.CreatedOn);
        }

        [Test]
        public void GetUserByUserId()
        {
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            IUserMaster UserMasterRepository = new UserMasterRepository(configuration);
            IEcomlogger EcomLoggerRepository = new EcomLoggerRepository();

            UserMasterController controller = this.createController(UserMasterRepository, EcomLoggerRepository);

            ActionResult result = (ActionResult)controller.GetUserByUserId(3);
            Assert.IsNotNull(result);
            Assert.AreEqual("GetCategoryById executed successfully.",((EcommerceAPI.Model.ResponseModel)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value).Message);
            Assert.AreEqual("OK",((EcommerceAPI.Model.ResponseModel)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value).statusCode);
        }
        #endregion
    }
}