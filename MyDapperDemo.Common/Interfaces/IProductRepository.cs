using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapperDemo.Common.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<IProduct> GetAll();
        IEnumerable<IProduct> GetAllWithCategory();      
    }
}
