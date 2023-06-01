using Microsoft.EntityFrameworkCore;

namespace api_minima_csharp
{
    public class Book
    {
        public Book(int id, string name, decimal price) 
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class BookDb : DbContext
{
    public BookDb(DbContextOptions options) : base(options) { }
    public DbSet<Book> Books { get; set; } = null!;
}
}
