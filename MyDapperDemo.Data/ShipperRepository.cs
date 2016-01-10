using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

using MyDapperDemo.Common.Interfaces;
using MyDapperDemo.Entities;

namespace MyDapperDemo.Data
{
    public class ShipperRepository : BaseRepository, IShipperRepository
    {
        public ShipperRepository()
        {

        }

        public ShipperRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public IEnumerable<IShipper> GetAll()
        {
            using (IDbConnection connection = GetOpenConnection())
            {
                //string query = "SELECT [Shipper ID] As ShipperId, [Company Name] As CompanyName FROM Shippers;";
                string query = Properties.Resources.Shipper_List_Get;
                return connection.Query<Shipper>(query);
            }
        }

        public IShipper GetShipperById(int shipperId)
        {
            using (IDbConnection connection = GetOpenConnection())
            {
                string query = "SELECT [Shipper ID] As ShipperId, [Company Name] As CompanyName FROM Shippers WHERE [Shipper Id] = @ShipperId;";
                return connection.Query<Shipper>(query, new { ShipperId = shipperId }).SingleOrDefault();
            }
        }

        public IShipper GetShipperByName(string companyName)
        {
            using (IDbConnection connection = GetOpenConnection())
            {
                string query = "SELECT [Shipper ID] As ShipperId, [Company Name] As CompanyName FROM Shippers WHERE [Company Name] = @CompanyName;";
                return connection.Query<Shipper>(query, new { CompanyName = companyName }).SingleOrDefault();
            }
        }       

        public int InsertShipper(IShipper shipper)
        {
            using (IDbConnection connection = GetOpenConnection())
            {
                string query = "INSERT INTO Shippers ([Company Name]) VALUES (@CompanyName);";
                return connection.Execute(query, shipper);
            }
        }

        public int InsertShipper2(IShipper shipper)
        {
            using (IDbConnection connection = GetOpenConnection())
            {
                //SQL SERVER ONLY
                //string query = "INSERT INTO Shippers ([Company Name]) VALUES (@CompanyName); SELECT CAST(SCOPE_IDENTITY() as int);";
                string query = "INSERT INTO Shippers ([Company Name]) VALUES (@CompanyName); SELECT CAST(@@IDENTITY as int);";
                try
                {
                    shipper.ShipperId = connection.Query<int>(query, shipper).Single();
                }
                catch (Exception ex)
                {

                }

                if(shipper.ShipperId > 0)
                    return 1;

                return 0;
            }
        }

        public int UpdateShipper(IShipper shipper)
        {
            using (IDbConnection connection = GetOpenConnection())
            {
                string query = "UPDATE Shippers SET [Company Name] = @CompanyName WHERE [Shipper Id] = @ShipperId;";
                return connection.Execute(query, shipper);
            }
        }

        public int DeleteShipper(int shipperId)
        {
            using (IDbConnection connection = GetOpenConnection())
            {
                string query = "DELETE FROM Shippers WHERE [Shipper ID] = @ShipperId;";
                return connection.Execute(query, new { ShipperId = shipperId });
            }
        }

        public override string ToString()
        {
            return base.ConnectionString;
        }
    }
}
