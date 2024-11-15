using System.Collections.Generic;

using ContosoCrafts.Website.Models;
using ContosoCrafts.Website.Services;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.Website.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> logger;

    public JsonFileProductService productService;

    public IEnumerable<Product> Products { get; private set; }

    public IndexModel(
        ILogger<IndexModel> logger,
        JsonFileProductService productService)
    {
        this.logger = logger;
        this.productService = productService;
    }

    public void OnGet()
    {
        Products = productService.GetProducts();
    }
}
