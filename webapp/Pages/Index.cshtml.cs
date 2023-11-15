using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp.Models;
using webapp.Services;

namespace webapp.Pages;

public class IndexModel : PageModel
{
    public required List<Product> Products { get; set; }
    public readonly IProductService _productService;

    public IndexModel(IProductService productService)
    {
        _productService = productService;
    }

    public void OnGet()
    {
        Products = _productService.GetProducts();

    }
}

