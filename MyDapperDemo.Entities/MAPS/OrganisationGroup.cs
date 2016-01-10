using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapperDemo.Entities.MAPS
{
    public class OrganisationGroup
    {
        public int OrganisationGroupID { get; set; }
        public int OrganisationID { get; set; }
        public int GroupID { get; set; }
        public int FinancialOrganisationID { get; set; }
        public int BankAccountID { get; set; }
        public DateTime ActiveDate { get; set; }
    }
}
