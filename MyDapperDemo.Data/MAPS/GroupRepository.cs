using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using MyDapperDemo.Entities.MAPS;

namespace MyDapperDemo.Data.MAPS
{
    public class GroupRepository : BaseRepository
    {
        public IEnumerable<Group> GetAllGroups()
        {
            using (var connection = GetOpenMapsConnection())
            {
                string query = @"SELECT TOP 20 * FROM tblGroup WHERE InactiveDate IS NULL ORDER BY GroupDesc";

                return connection.Query<Group>(query);
            }
        }

    }
}
