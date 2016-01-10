using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using MyDapperDemo.Entities.MAPS;

namespace MyDapperDemo.Data.MAPS
{
    public class PersonRepository : BaseRepository
    {
        public int AddPerson(Person person)
        {
            using (var connection = GetOpenMapsConnection())
            {
                string query = Properties.Resources.Person_Insert;
                person.PersonId = connection.Query<int>(query, person).Single();

                if (person.PersonId > 0)
                {
                    return 1;
                }

                return 0;
            }
        }

        public IEnumerable<Person> GetAllPeople()
        {
            using (var connection = GetOpenMapsConnection())
            {
                string query = Properties.Resources.Person_List_Get;

                return connection.Query<Person>(query);
            }
        }

        public Person GetPersonWithOrganisation(int personId)
        {
            using (var connection = GetOpenMapsConnection())
            {
                string query = @"SELECT * FROM tblPerson P 
                                 INNER JOIN tblOrganisation O On P.PersonId = O.PrivateId
                                 WHERE P.PersonId = @PersonId";

                return connection.Query<Person, Organisation, Person>(query,
                    (p, o) =>
                    {
                        p.Organisation = o;
                        return p;
                    }, 
                    new { PersonId = personId },
                    splitOn: "OrganisationId"
                ).SingleOrDefault();                    
            }
        }    
    }
}
