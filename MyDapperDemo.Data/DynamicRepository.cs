using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using MyDapperDemo.Entities;

namespace MyDapperDemo.Data
{
    public class DynamicRepository : BaseRepository
    {
        public IEnumerable<dynamic> GetAllCategories()
        {
            using (var connection = GetOpenConnection())
            {
                string query = @"SELECT [Category ID] As CategoryId, [Category Name] As CategoryName, Description, Picture FROM Categories";
                return connection.Query<dynamic>(query);
            }
        }        
    }
}
