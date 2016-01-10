using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using DapperExtensions;
using MyDapperDemo.Entities.MAPS;

namespace MyDapperDemo.Data.MAPS
{
    public class TitleRepository : BaseRepository
    {       
        public IEnumerable<Title> GetAllTitles()
        {
            using (var connection = GetOpenMapsConnection())
            {
                string query = "stp_Title_List";

                return connection.Query<Title>(query, commandType: CommandType.StoredProcedure);
            }
        }

        /*
        public IEnumerable<Title> GetAllTitles2()
        {
            using (var connection = GetOpenMapsConnection())
            {
                return connection.GetList<Title>();
            }
        }  
         * */
    }
}
