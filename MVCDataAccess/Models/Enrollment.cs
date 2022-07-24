using System.ComponentModel.DataAnnotations;

namespace MVCDataAccess.Models;

public class Enrollment
{
    [Key]
    public int EnrollmentId {get; set;}
    [Required]
    public int StudentId {get;set;}
    public Student Student {get;set;}
    public int BookId {get;set;}
    public List<Book> Books {get;set;}
}