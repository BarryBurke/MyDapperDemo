using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapperDemo.Common.Interfaces
{
    public interface ICategory
    {
        int CategoryId { get; set; }
        string CategoryName { get; set; }
        string Description { get; set; }
        byte[] Picture { get; set; }

        IEnumerable<IProduct> Products { get; set; }
    }
}
