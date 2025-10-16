using DataServiceLayer;
using DataServiceLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
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
        var categories = _dataService.GetCategories().Select(c => new CategoryModel
        {
            Id = c.Id,
            Url = $"/api/categories/{c.Id}",
            Name = c.Name,
            Description = c.Description
        });

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

        var model = new CategoryModel
        {
            Id = category.Id,
            Url = $"/api/categories/{category.Id}",
            Name = category.Name,
            Description = category.Description
        };

        return Ok(model);
    }

    [HttpPost]
    public IActionResult CreateCategory(CreateCategoryModel model)
    {
        var category = _dataService.CreateCategory(model.Name, model.Description);

        var responseModel = new CategoryModel
        {
            Id = category.Id,
            Url = $"/api/categories/{category.Id}",
            Name = category.Name,
            Description = category.Description
        };

        return Created($"/api/categories/{category.Id}", responseModel);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        if (_dataService.DeleteCategory(id))
        {
            return Ok();
        }

        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, UpdateCategoryModel model)
    {
        var success = _dataService.UpdateCategory(id, model.Name, model.Description);

        if (!success)
        {
            return NotFound();
        }

        var category = _dataService.GetCategory(id);

        var responseModel = new CategoryModel
        {
            Id = category.Id,
            Url = $"/api/categories/{category.Id}",
            Name = category.Name,
            Description = category.Description
        };

        return Ok(responseModel);
    }
}