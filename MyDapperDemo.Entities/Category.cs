using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyDapperDemo.Common.Interfaces;

namespace MyDapperDemo.Entities
{
    public class Category : ICategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public IEnumerable<IProduct> Products { get; set; }
    }
}
