namespace MVCDataAccess.Models;

public class CheckOut
{
    public int Id {get;set;}
    public int StudentId{get;set;}
    public Student Student {get;set;}
    public List<Book> Books {get;set;}
    public List<BookPrice> BookPrices {get;set;}
}