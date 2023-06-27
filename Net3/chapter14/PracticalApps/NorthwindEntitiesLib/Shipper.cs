using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public class Shipper
    {
        public int ShipperID { get; set; }

        public string ShipperName { get; set; }

        public string Phone { get; set; }

        // related entities 
        public ICollection<Order>  orders { get; set; }

    }
}
