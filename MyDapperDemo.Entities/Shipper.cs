using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyDapperDemo.Common.Interfaces;

namespace MyDapperDemo.Entities
{
    public class Shipper : IShipper
    {
        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
    }
}
