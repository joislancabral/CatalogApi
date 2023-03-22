using ApiCatalog.Context;
using ApiCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controller;
[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }
    //View products list
    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        var products = _context.Products.AsNoTracking().ToList();
        if(products is null)
        {
            return NotFound("Products not found.");
        }
        return products;
    }
    //View product by id
    [HttpGet("{id:int}", Name="GetProduct")]
    public ActionResult<Product> Get(int id)
    {
        var product = _context.Products.AsNoTracking().FirstOrDefault(p => p.ProductId == id);
        if (product is null)
        {
            return NotFound("Product not found.");
        }
        return product;
    }
    //Create product
    [HttpPost]
    public ActionResult Post(Product product)
    {
        if(product is null)
        {
            return BadRequest("Invalid data entered.");
        }
        _context.Products.Add(product);
        _context.SaveChanges();

        return new CreatedAtRouteResult("GetProduct", new {id = product.ProductId}, product);
    }
    //Modify produt
    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Product product)
    {
        if(id != product.ProductId)
        {
            return BadRequest("The server cannot process the request.");
        }

        _context.Entry(product).State = EntityState.Modified;
        _context.SaveChanges();
        return Ok(product);
    }
    //Delete product
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
        if(product is null)
        {
            return NotFound("Product not found."); 
        }
        _context.Products.Remove(product);
        _context.SaveChanges();
        return Ok(product);
    }

}