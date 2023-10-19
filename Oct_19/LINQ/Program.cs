

// =============== LINQ ==================
// Stands for: Language Integrated Query
// Gives you the capability to query:
// - Objects in memory, eg collections(LINQ to Objects)
// - Databases (LINQ to Entities)
// - XML (LINQ to XML)
// - ADO.NET Data Sets (LINQ to Data Sets)


internal class Program
{

    public class Book
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>() {
                new Book() {Title="1st Book", Price=10},
                new Book() {Title="2nd Book", Price=5.2f},
                new Book() {Title="3rd Book", Price=3},
                new Book() {Title="4th Book", Price=7},
                new Book() {Title="5th Book", Price=2},

            };
        }
    }

    private static void Main(string[] args)
    {
        
        var books = new BookRepository().GetBooks();

        var cheapBooks = books.Where(book => book.Price < 100);


        var sortedBooks = books.OrderBy((book) => book.Price);

        var BookTitles = books.Select((book)=>book.Title);


        // LINQ Query Operators
        var cheaperbooks =
            from b in books
            where b.Price < 200
            orderby b.Title
            select b;


        // LINQ Extenstion methods
        var chainedQueries = books
                                  .Where(book => book.Price < 100)
                                  .OrderBy(book => book.Price)
                                  .Select(book => book.Title);

        //foreach (var book in BookTitles)
        //{
        //    Console.WriteLine(book);
        //}

        var book = books.Single(book => book.Title == "3rd Book"); // This gives an exception if the object is not there.
        var book1 = books.SingleOrDefault(book => book.Title == "3rd Book"); // This does not give an exception in the above case and return null.
        var book2 = books.First(book => book.Title == "3rd Book"); // This does not give an exception in the above case and return null.
        var book3 = books.FirstOrDefault(book => book.Title == "3rd Book"); // This does not give an exception in the above case and return null.
        var book4 = books.Last(book => book.Title == "3rd Book"); // This does not give an exception in the above case and return null.
        var book5 = books.LastOrDefault(book => book.Title == "3rd Book"); // This does not give an exception in the above case and return null.
        var pagedBooks = books.Skip(2).Take(3);

        var count = books.Count();
        var expensiveBook = books.Max(book => book.Price);
        var cheapestBook = books.Min(book => book.Price);
        var TotalPrice = books.Sum(book => book.Price);
        var AvgPrice = books.Average(book => book.Price);


        Console.WriteLine(expensiveBook);
        foreach (var b in pagedBooks)
        {
            Console.WriteLine(b.Title);
        }

        //Console.WriteLine(book6);

    }
}