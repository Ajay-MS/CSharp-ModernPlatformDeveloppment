using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace NorthwindWeb.Pages
{
    public class SupplierModel : PageModel
    {
        private Northwind db;
        public IEnumerable<string>  Suppliers { get; set; }

        [BindProperty]
        public Supplier Supplier { get; set; }

        public IActionResult onPost()
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }

            return Page();
        }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";

            Suppliers = db.Suppliers.Select(s => s.CompanyName);

        }

        public SupplierModel(Northwind injectedContext) {
            db = injectedContext;
        }
    }
}
