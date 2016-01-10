using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapperDemo.Entities.MAPS
{
    public class Person
    {
        public int PersonId { get; set; }
        public int TitleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string DirectEmail { get; set; }
        public int RegistrationTypeID { get; set; }
        public int RegistrationNumber { get; set; }

        public Organisation Organisation { get; set; }
    }
}
