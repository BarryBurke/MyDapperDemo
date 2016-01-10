using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyDapperDemo.Common.Interfaces;

namespace MyDapperDemo.BusinessLogic
{
    public class ShipperAction
    {
        public IShipperRepository ShipperRepository { get; set; }

        public ShipperAction(IShipperRepository repository)
        {
            ShipperRepository = repository;
        }

        public double CalculateShippingTotal()
        {
            
            return 3002.43;
        }
    }
}
