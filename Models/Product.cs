using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalog.Models;
[Table("Products")]
public class Product
{
    [Key]
    public int ProductId {get; set;}
    [Required]
    [StringLength(80)]
    public string? Name{get; set;}
    [Required]
    [StringLength(300)]
    public string? Description {get; set;}
    [Required]
    [Column(TypeName ="decimal(10,2)")]
    public decimal Price {get; set;}
    [Required]
    [StringLength(300)]
    public string? ImageUrl {get; set;}
    public int Stock {get; set;}
    public DateTime DateRegistration {get; set;}
    public int CategoryId {get;set;}
    public Category? Category{get; set;}            
}