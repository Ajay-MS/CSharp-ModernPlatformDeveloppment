using Packt.Shared;

namespace NorthwindMvc.Models
{
    public class IndexViewModel
    {

    }

    public class HomeViewModel
    {
        public int VisitorCount;

        public IList<Category> Categories { get; set; }

        public IList<Product> Products { get; set; }
    }
}
