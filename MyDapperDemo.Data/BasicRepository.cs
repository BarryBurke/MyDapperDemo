using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using DapperExtensions;

using MyDapperDemo.Common.Interfaces;
using MyDapperDemo.Entities;

namespace MyDapperDemo.Data
{
    public class BasicRepository : BaseRepository
    {
        public ICategory GetAllCategoryProductsByCategoryId(int categoryId)
        {
            using (var connection = GetOpenConnection())
            {
                string query = @"SELECT [Category ID] As CategoryId, [Category Name] As CategoryName, Description, Picture FROM Categories WHERE [Category ID] = @CategoryID 
                                 SELECT [Product ID] As ProductId, [Supplier ID] As SupplierId, [Product Name] As ProductName FROM Products WHERE [Category ID] = @CategoryID";

                try
                {
                    using (var multi = connection.QueryMultiple(query, new { CategoryId = categoryId }))
                    {

                        var category = multi.Read<ICategory>().Single();
                        var products = multi.Read<IProduct>().ToList();

                        //category.Products = products;
                        return category;
                    }
                }
                catch (Exception ex)
                {
                }
                return null;
            }
        }

        public IEnumerable<IProduct> GetProductsByCategoryIdUsingStoredProc(int categoryId)
        {
            using (var connection = GetOpenConnection())
            {
                string query = @"stp_GetProductsByCategoryId";
                return connection.Query<IProduct>(query, new { CategoryId = categoryId }, commandType: CommandType.StoredProcedure);
            }
        }

        public int GetNumberOfProducts()
        {
            using (var connection = GetOpenConnection())
            {
                try
                {
                    //var items = connection.GetList<Product>("Products");
                    //return connection.Count<Product>(null);                    
                }
                catch (Exception ex)
                {

                }
                return 0;
            }
        }
    }
}
