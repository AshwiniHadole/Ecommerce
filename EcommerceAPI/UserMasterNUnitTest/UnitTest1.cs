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
    public class Tests
    {
        #region Configuration
        private IConfiguration initConfiguration()
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("./appsettings.Development.json")
                .AddEnvironmentVariables()
                .Build();
            return configuration;
        }
        #endregion

        #region Controller
        private UserMasterController createController(IUserMaster _user)
        {
            var controller = new UserMasterController(_user);
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

            IUserMaster UserMasterRepository = new UserMasterRepository(configuration);;

            UserMasterController controller = this.createController(UserMasterRepository);

            ActionResult blomodel = (ActionResult)controller.InsertNewUser(usermaster);
        }
        [Test]
        public void GetUserByUserId()
        {
            var configuration = this.initConfiguration();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddMemoryCache();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            IUserMaster UserMasterRepository = new UserMasterRepository(configuration); ;

            UserMasterController controller = this.createController(UserMasterRepository);

            ActionResult blomodel = (ActionResult)controller.GetUserByUserId(36);
        }
        #endregion
    }
}