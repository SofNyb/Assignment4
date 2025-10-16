using DataServiceLayer;
using DataServiceLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
using WebServiceLayer.Models;

namespace WebServiceLayer.Controllers;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    DataService _dataService = Program.DataService;

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _dataService.GetProducts().Select(c => new ProductModel
        {
            Id = c.Id,
            Url = $"/api/products/{c.Id}",
            Name = c.Name,
        });

        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var products = _dataService.GetProduct(id);

        if (products == null)
        {
            return NotFound();
        }

        var model = new ProductModel
        {
            Id = products.Id,
            Url = $"/api/products/{products.Id}",
            Name = products.Name,
            UnitPrice = products.UnitPrice,
            CategoryId = products.CategoryId,
            Category = products.Category,
            QuantityPerUnit = products.QuantityPerUnit,
            UnitsInStock = products.UnitsInStock
        };

        return Ok(model);
    }
}
