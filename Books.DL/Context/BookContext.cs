using System.Data.Entity;
using Books.Models;

namespace Books.DL
{
    public class BookContext : DbContext
    {
        public BookContext() : base("name=BookContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        public DbSet<Book> Books { get; set; }
    }
}