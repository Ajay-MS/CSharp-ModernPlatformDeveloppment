using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public class Product
    {

        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

       /* public short? UnitInStock { get; set; }*/

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLEvel { get; set; }

        public bool Discontinued { get; set; }
    }
}
