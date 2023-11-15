using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp.Models;
using webapp.Services;

namespace webapp.Pages;

public class IndexModel : PageModel
{
    public required List<Product> Products { get; set; }

    public void OnGet()
    {
        ProductService productService = new();
        Products = productService.GetProducts();

    }
}

