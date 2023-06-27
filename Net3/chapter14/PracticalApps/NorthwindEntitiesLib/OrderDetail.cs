using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public class OrderDetail
    {
        public int orderID { get; set; }

        public int ProductID { get; set; }

        public decimal UnitPrice { get; set; } = 0;

        public short Quantity { get; set; } = 1;

        public double Discount { get; set; } = 0;


        // related entities 
        public Order order { get; set; }

        public Product product { get; set; }

    }
}
