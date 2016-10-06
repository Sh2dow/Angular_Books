using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        
    }

    public class BookDetailDTO : BookDTO
    {
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
    }

    public class Book : BookDetailDTO
    {
        [Required]
        public new string Author { get; set; }
        [Required]
        public new string Title { get; set; }
    }
}