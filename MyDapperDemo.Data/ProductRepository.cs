using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using MyDapperDemo.Common.Interfaces;
using MyDapperDemo.Entities;

namespace MyDapperDemo.Data
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public IEnumerable<IProduct> GetAll()
        {
            using (var connection = GetOpenConnection())
            {
                string query = @"SELECT [Product ID] As ProductId, [Category Id] As CategoryId, [Supplier ID] As SupplierId, [Product Name] As ProductName
                                FROM Products";

                return connection.Query<Product>(query);
            }
        }

        public IEnumerable<IProduct> GetAllWithCategory()
        {
            using (var connection = GetOpenConnection())
            {
                string query = @"SELECT P.[Product ID] As ProductId, P.[Supplier ID] As SupplierId, P.[Product Name] As ProductName, C.[Category Id] As CategoryId, C.[Category Name] As CategoryName 
                                FROM Products P
                                LEFT OUTER JOIN Categories C ON P.[Category ID] = C.[Category ID]
                                ";

                return connection.Query<Product, Category, Product>(query, 
                                        (p, c) => 
                                        { 
                                            p.Category = c; 
                                            return p; 
                                        }, 
                                        splitOn: "CategoryName");                
            }
            //C.[Category Id] As CategoryId,   CategoryId,
        }   

    }
}
