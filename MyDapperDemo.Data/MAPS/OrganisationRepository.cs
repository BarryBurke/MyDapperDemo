using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using MyDapperDemo.Entities.MAPS;

namespace MyDapperDemo.Data.MAPS
{
    public class OrganisationRepository : BaseRepository
    {
        public int AddOrganisation(Organisation org)
        {
            using (var connection = GetOpenMapsConnection())
            {
                string query = @"INSERT INTO tblOrganisation (OrganisationName, Phone, MailEnabled) VALUES (@OrganisationName, @Phone, @MailEnabled);";
                return connection.Execute(query, org);
            }
        }

        public int AddOrganisation2(Organisation org)
        {
            using (var connection = GetOpenMapsConnection())
            {
                string query = @"INSERT INTO tblOrganisation (OrganisationName, Phone, MailEnabled) VALUES (@OrganisationName, @Phone, @MailEnabled);
                                 SELECT CAST(SCOPE_IDENTITY() as int);";
                org.OrganisationId = connection.Query<int>(query, org).Single();

                if (org.OrganisationId > 0)
                {
                    return 1;
                }

                return 0;
            }
        }

        public IEnumerable<Organisation> GetAllOrganisations()
        {
            using (var connection = GetOpenMapsConnection())
            {
                string query = @"SELECT TOP 20 * FROM tblOrganisation WHERE OrganisationName IS NOT NULL AND OrganisationTypeId IS NULL AND PrivateId IS NULL ORDER BY EnteredDate DESC";

                return connection.Query<Organisation>(query);
            }
        }
/*
        public IEnumerable<Organisation> GetAllOrganisationsWithGroups()
        {
            using (var connection = GetOpenMapsConnection())
            {
                string query = @"SELECT TOP 20 * FROM tblOrganisation O
                                 INNER JOIN tblOrganisationGroup OG On O.OrganisationId = OG.OrganisationId 
                                 INNER JOIN tblGroup G ON OG.GroupId = G.GroupId
                                 WHERE OrganisationName IS NOT NULL AND PrivateId IS NULL ORDER BY EnteredDate DESC";

                return connection.Query<Organisation, Group, Organisation>(query);
            }
        }
*/

        public Organisation GetOrganisationWithGroups(int organisationId)
        {
            using (var connection = GetOpenMapsConnection())
            {
                string query = @"SELECT * FROM tblOrganisation WHERE OrganisationId = @OrganisationId 
                                 SELECT G.* FROM tblGroup G 
                                 INNER JOIN tblOrganisationGroup OG ON G.GroupId = OG.GroupId 
                                 WHERE OG.OrganisationId = @OrganisationId";

                try
                {
                    using (var multi = connection.QueryMultiple(query, new { OrganisationId = organisationId }))
                    {
                        var org = multi.Read<Organisation>().SingleOrDefault();
                        if (org != null)
                        {
                            var groups = multi.Read<Group>().ToList();
                            org.Groups = groups;
                        }
                        return org;
                    }
                }
                catch (Exception ex)
                {
                }
                return null;
            }
        }    

        public IEnumerable<Organisation> GetAllOrganisationsInGroupId(int GroupId)
        {
            using (var connection = GetOpenMapsConnection())
            {
                string query = @"SELECT * FROM tblOrganisation O
                                 INNER JOIN tblOrganisationGroup OG On O.OrganisationId = OG.OrganisationId 
                                 WHERE OG.GroupId = @GroupId AND OG.InactiveDate IS NULL 
                                 ORDER BY O.OrganisationName";

                return connection.Query<Organisation>(query, new { GroupId = GroupId });
            }
        }

        public dynamic GetAllBankAccounts()
        {
            using (var connection = GetOpenMapsConnection())
            {
                string query = @"SELECT * FROM tblBankAccount";

                return connection.Query<dynamic>(query);
            }
        }
    }
}
