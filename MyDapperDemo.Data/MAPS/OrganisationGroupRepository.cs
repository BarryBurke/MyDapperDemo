using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using MyDapperDemo.Entities.MAPS;

namespace MyDapperDemo.Data.MAPS
{
    public class OrganisationGroupRepository : BaseRepository
    {
        public IEnumerable<Person> GetOrganisationsByGroupId(int groupId)
        {
            using (var connection = GetOpenMapsConnection())
            {
                string query = @"SELECT * FROM tblOrganisationGroup WHERE GroupId = @GroupId";

                return connection.Query<Person>(query, new { GroupId = groupId });
            }
        }

    }
}
