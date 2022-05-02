using Dapper;
using EcommerceAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EcommerceAPI.Repository
{
    public class StoreRepository : IStoreRepository
    {
         private readonly IConfiguration _config;
         public StoreRepository(IConfiguration config)
         {
            this._config = config;
         }
        #region IDbConnection
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(this._config.GetConnectionString("EmployeeAppCon"));
            }
        }
        #endregion

        #region Delete Store
        public void DeleteStoreById(int Id)
        {
            using (IDbConnection Conn = new SqlConnection(this._config.GetSection("ConnectionStrings").GetSection("EmployeeAppCon").Value))
            {
                Conn.Execute(@"UPDATE TblStore SET Active=0 WHERE UserId=@UserId ", new
                { UserId = Id });
            }
        }
        #endregion

        #region Get All Store
        public IEnumerable<Store> GetAllStore(int userid)
        {
            IEnumerable<Store> stores = new List<Store>();
            using (IDbConnection Conn = new SqlConnection(this._config.GetSection("ConnectionStrings").GetSection("EmployeeAppCon").Value))
            {
                stores = Conn.Query<Store>(@"SELECT*FROM TblStore WHERE UserId=@UserId AND Active=1", new
                { UserId = userid }).ToList(); 

            }
            return stores;
        }
        #endregion

        #region Get store
        public Store GetStoreById(int storeid)
        {
            Store store = new Store();
            using (IDbConnection Conn = new SqlConnection(this._config.GetSection("ConnectionStrings").GetSection("EmployeeAppCon").Value))
            {
                store = Conn.Query<Store>(@"SELECT*FROM TblStore WHERE StoreId=@storeid AND Active=1", new
                { StoreId = storeid }).FirstOrDefault();
            }
            return store;
        }
        #endregion

        #region Add Store
        public string CreateStore(Store store)
        {
            string A = "";

            using (IDbConnection Conn = new SqlConnection(this._config.GetSection("ConnectionStrings").GetSection("EmployeeAppCon").Value))
            {
                if (checkduplicate(store.Name))
                {
                    A = "Name already exist";
                }
                else
                {
                    Conn.Execute(@"INSERT INTO TblStore VALUES (@UserId,@Name,@TagLine,@Theme,@BackGroundImage,@SupportsMultipleLang,@StoreRoute,@CreatedOn,@CreatedBy,@Active)", new
                    {
                        UserId = store.UserId,
                        Name = store.Name,
                        TagLine = store.TagLine,
                        Theme = store.Theme,
                        BackGroundImage = store.BackGroundImage,
                        SupportsMultipleLang = store.SupportsMultipleLang,
                        StoreRoute = store.StoreRoute,
                        CreatedOn = System.DateTime.Now,
                        CreatedBy = store.CreatedBy,
                        Active = store.Active,
                    });
                    A = "Data inserted successfully";
                }
                return A;
            }
        }

        private bool checkduplicate(object name)
        {
            Store data = new Store();
            using (IDbConnection Conn = new SqlConnection(this._config.GetSection("ConnectionStrings").GetSection("EmployeeAppCon").Value))
            {
                data = Conn.Query<Store>(@"SELECT*FROM TblStore WHERE Name=@Name ", new
                { Name = name }).FirstOrDefault();
            }
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion



        #region Update store
        public void UpdateStoreById(Store store)
        {
            using (IDbConnection Conn = new SqlConnection(this._config.GetSection("ConnectionStrings").GetSection("EmployeeAppCon").Value))
            {
                Conn.Execute(@"UPDATE TblStore SET UserId=@UserId,Name=@Name,TagLine=@TagLine,Theme=@Theme,BackGroundImage=@BackGroundImage,SupportsMultipleLang=@SupportsMultipleLang,StoreRoute=@StoreRoute,CreatedOn=@CreatedOn,CreatedBy=@CreatedBy,Active=@Active WHERE StoreId=@StoreId", new
                {
                   StoreId=store.StoreId,
                    UserId = store.UserId,
                    Name = store.Name,
                    TagLine = store.TagLine,
                    Theme = store.Theme,
                    BackGroundImage = store.BackGroundImage,
                    SupportsMultipleLang = store.SupportsMultipleLang,
                    StoreRoute = store.StoreRoute,
                    CreatedOn = System.DateTime.Now,
                    CreatedBy = store.CreatedBy,
                    Active = store.Active
                });
            }
        }
        #endregion
    }
}
