using System.Collections.Generic;
using System.Text.Json;

using ContosoCrafts.Website.Models;
using ContosoCrafts.Website.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.Website;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddTransient<JsonFileProductService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.MapGet("/products", (context) =>
        {
            var products = app.Services.GetService<JsonFileProductService>().GetProducts();
            var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
            return context.Response.WriteAsync(json);
        });

        app.Run();
    }
}
