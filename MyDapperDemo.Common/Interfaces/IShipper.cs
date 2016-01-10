using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapperDemo.Common.Interfaces
{
    public interface IShipper
    {
        int ShipperId { get; set; }
        string CompanyName { get; set; }
    }
}
