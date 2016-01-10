using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyDapperDemo.Common.Interfaces;

namespace MyDapperDemo.Tests.Mocks
{
    public class MockShipperRepository : IShipperRepository
    {
        public IEnumerable<IShipper> GetAll()
        {
            throw new NotImplementedException();
        }

        public IShipper GetShipperById(int shipperId)
        {
            throw new NotImplementedException();
        }

        public IShipper GetShipperByName(string companyName)
        {
            throw new NotImplementedException();
        }

        public int InsertShipper(IShipper shipper)
        {
            throw new NotImplementedException();
        }

        public int UpdateShipper(IShipper shipper)
        {
            throw new NotImplementedException();
        }

        public int DeleteShipper(int shipperId)
        {
            throw new NotImplementedException();
        }
    }
}
