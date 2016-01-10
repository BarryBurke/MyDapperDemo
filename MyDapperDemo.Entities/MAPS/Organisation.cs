using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapperDemo.Entities.MAPS
{
    public class Organisation
    {
        public int OrganisationId { get; set; }
        public string OrganisationName { get; set; }
        public string MailingStreetAddress { get; set; }
        public string MailingSuburb { get; set; }
        public string MailingCity { get; set; }
        public string MailingPostCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PrivateId { get; set; }
        public int OrganisationType { get; set; }
        public bool MailEnabled { get; set; }
        public bool? Test { get; set; }

        public List<Group> Groups { get; set; }
    }
}
