using DataServiceLayer;
using DataServiceLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
using WebServiceLayer.Models;

namespace WebServiceLayer.Controllers;

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
}
