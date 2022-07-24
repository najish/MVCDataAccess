using System.ComponentModel.DataAnnotations;

namespace MVCDataAccess.Models;


public class BookPrice
{
    [Key]
    public int Id {get;set;}
    [Required]
    public double Amount{get;set;}
    [Required]

    public double BasePrice {get;set;}
    [Required]

    public double PerDayPrice {get;set;}

    public Book? BookId {get;set;}
    public List<Book>? Books {get;set;}
}