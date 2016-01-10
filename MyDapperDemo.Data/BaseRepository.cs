using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using Dapper;

namespace MyDapperDemo.Data
{
    public abstract class BaseRepository
    {
        protected string ConnectionString { get; set; }

        protected static IDbConnection GetOpenConnection()
        {
            return GetOpenConnection(@"Data Source = .\DataFiles\Northwind.sdf");          
        }

        protected static IDbConnection GetOpenConnection(string connectionString)
        {
            //IDbConnection connection = new SqlCeConnection(connectionString);
            IDbConnection connection = new SqlCeConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (SqlCeException ex)
            {
                throw;
            }

            return connection;
        }

        protected static IDbConnection GetOpenMapsConnection()
        {
            IDbConnection connection = new SqlConnection(@"Server=WNT15;Database=MAPS;Trusted_Connection=True;");

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw;
            }

            return connection;
        }
    }
}
