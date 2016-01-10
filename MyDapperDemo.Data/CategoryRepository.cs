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
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public IEnumerable<ICategory> GetAll()
        {
            using (var connection = GetOpenConnection())
            {
                try
                {
                    string query = @"SELECT [Category ID] As CategoryId, [Category Name] As CategoryName, Description, Picture FROM Categories";
                    return connection.Query<Category>(query);
                }
                catch (Exception ex)
                {

                }
                return null;
            }
        }

    }
}
