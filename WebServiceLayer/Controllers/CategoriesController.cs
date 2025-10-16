using DataServiceLayer;
using DataServiceLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebServiceLayer.Models;

namespace WebServiceLayer.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{

    DataService _dataService = Program.DataService;

    [HttpGet]
    public IActionResult GetCategories()
    {
        var categories = _dataService.GetCategories();

        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
        var category = _dataService.GetCategory(id);

        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public IActionResult CreateCategory(CreateCategoryModel model)
    {
        var category = _dataService.CreateCategory(model.Name, model.Description);

        return Created($"/api/categories/{category.Id}", category);
    }
}