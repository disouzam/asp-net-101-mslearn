using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using ContosoCrafts.Website.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.Website.Services;

public class JsonFileProductService
{
    public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
    {
        WebHostEnvironment = webHostEnvironment;
    }

    public IWebHostEnvironment WebHostEnvironment { get; }

    private string jsonFileName
    {
        get
        {
            return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");
        }
    }

    public IEnumerable<Product> GetProducts()
    {
        using (var jsonFileReader = File.OpenText(jsonFileName))
        {
#pragma warning disable CS8603 // Possible null reference return.
            return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
