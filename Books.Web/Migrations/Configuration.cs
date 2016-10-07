namespace Books.Web.Migrations
{
    using DL;
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BooksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BooksContext context)
        {
            context.Books.AddOrUpdate(x => x.Id,
                new Book()
                {
                    Id = 1,
                    Title = "Pride and Prejudice",
                    Year = 1813,
                    Author = "Jane Austen",
                    Price = 9.99M,
                    Genre = "Commedy of manners"
                },
                new Book()
                {
                    Id = 2,
                    Title = "Northanger Abbey",
                    Year = 1817,
                    Author = "Jane Austen",
                    Price = 12.95M,
                    Genre = "Gothic parody"
                },
                new Book()
                {
                    Id = 3,
                    Title = "David Copperfield",
                    Year = 1850,
                    Author = "Charles Dickens",
                    Price = 15,
                    Genre = "Bildungsroman"
                },
                new Book()
                {
                    Id = 4,
                    Title = "Don Quixote",
                    Year = 1617,
                    Author = "Miguel de Cervantes",
                    Price = 8.95M,
                    Genre = "Picaresque"
                });
        }
    }
}
