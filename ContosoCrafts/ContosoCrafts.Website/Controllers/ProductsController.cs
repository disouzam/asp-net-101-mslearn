using System.Collections.Generic;

using ContosoCrafts.Website.Models;
using ContosoCrafts.Website.Services;

using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.Website.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    public JsonFileProductService ProductService { get; }

    public ProductsController(JsonFileProductService jsonFileProductService)
    {
        ProductService = jsonFileProductService;        
    }

    [HttpGet]
    public IEnumerable<Product> GetProducts()
    {
        return ProductService.GetProducts();
    }

    [HttpGet]
    [Route("Rate")]

    public ActionResult Get(
        [FromQuery] string productId,
        [FromQuery] int rating
    )
    {
        ProductService.AddRating(productId, rating);
        return Ok();
    }
}
