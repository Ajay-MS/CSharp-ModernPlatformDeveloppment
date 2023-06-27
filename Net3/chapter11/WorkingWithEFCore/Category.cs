using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared
{
    class Category
    {
        // These properties map to the column in the database 

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        [Column(TypeName="ntext")]
        public string Description { get; set; }

        // Navigation property for the related rows 
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }
}
