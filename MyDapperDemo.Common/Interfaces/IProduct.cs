using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapperDemo.Common.Interfaces
{
    public interface IProduct
    {
        int ProductId { get; set; }
        int SupplierId { get; set; }
        int CategoryId { get; set; }
        string ProductName { get; set; }

        ICategory Category { get; set; }
    }
}
