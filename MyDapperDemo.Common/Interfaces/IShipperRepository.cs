using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDapperDemo.Common.Interfaces
{
    public interface IShipperRepository
    {
        IEnumerable<IShipper> GetAll();
        IShipper GetShipperById(int shipperId);
        IShipper GetShipperByName(string companyName);
        int InsertShipper(IShipper shipper);
        int UpdateShipper(IShipper shipper);
        int DeleteShipper(int shipperId);
    }
}
