using System.ComponentModel.DataAnnotations;

namespace MVCDataAccess.Models;



public class IssuedBook
{
    [Key]
    public int Id {get;set;}
    [Required]
    public Book Book {get;set;}
    [Required]
    public DateTime IssuedData {get;set;}
    [Required]
    public Student Student {get;set;}
}