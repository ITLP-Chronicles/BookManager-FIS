using SistemaDePeliculasCodigo.Entities;

namespace SistemaDeLibrosCodigo;

public class BookHub
{
    public List<Book> Books { get; set; }

    public BookHub()
    {
        Books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public bool DeleteBook(string title)
    {
        var movie = Books.FirstOrDefault(m => m.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase));
        return Books.Remove(movie);
    }

    public bool UpdateBook(string title, Book book)
    {
        var movieByTitle = Books.FirstOrDefault(m => m.Title == title);
        
        if (movieByTitle is null) return false;
        
        var index = Books.IndexOf(movieByTitle);
        
        if (index == -1) return false;
        
        Books[index] = book;
        return true;
    }

    public List<Book> GetAll()
    {
        return Books;
    }

    public Book? GetByTitle(string title)
    {
        return Books.FirstOrDefault(m => m.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase));
    }
}