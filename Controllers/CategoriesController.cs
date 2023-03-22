using ApiCatalog.Context;
using ApiCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controller;
[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("products")]
    public ActionResult<IEnumerable<Category>> GetCategoriesProducts()
    {
         var categories = _context.Categories.Include(p => p.Products).ToList();
        if (categories is null)
        {
            return NotFound("Categories not found.");
        }
        return categories;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Category>> Get()
    {
        var categories = _context.Categories.ToList();
        if (categories is null)
        {
            return NotFound("Categories not found.");
        }
        return categories;
    }

     //View product by id
    [HttpGet("{id:int}", Name="GetCategory")]
    public ActionResult<Category> Get(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        if (category is null)
        {
            return NotFound("Category not found.");
        }
        return Ok(category);
    }

    //Create product
    [HttpPost]
    public ActionResult Post(Category category)
    {
        if(category is null)
        {
            return BadRequest("Invalid data entered.");
        }
        _context.Categories.Add(category);
        _context.SaveChanges();

        return new CreatedAtRouteResult("GetCategory", new {id = category.CategoryId}, category);
    }

    //Modify produt
    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Category category)
    {
        if(id != category.CategoryId)
        {
            return BadRequest("The server cannot process the request.");
        }

        _context.Entry(category).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(category);
    }

     //Delete product
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        if(category is null)
        {
            return NotFound("Category not found."); 
        }
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return Ok(category);
    }
}