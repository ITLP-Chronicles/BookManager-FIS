using SistemaDeLibrosCodigo;
using SistemaDePeliculasCodigo.Entities;

namespace TestProject1;

public class BookHubTests
{
    private const string TestFilePath = "books.txt"; // Archivo de prueba temporal

    public BookHubTests()
    {
        // Antes de cada prueba, asegurarse de que el archivo de prueba no exista
        if (File.Exists(TestFilePath))
        {
            File.Delete(TestFilePath);
        }
    }

    [Fact]
    public void AddBook_ShouldAddBookToList()
    {
        // Arrange
        var bookHub = new BookHub();
        var book = new Book
        {
            Title = "Test Book",
            ReleaseYear = 2021,
            Duration = 120,
            Genres = new List<string> { "Fiction" },
            Language = "English",
            Summary = "A test book",
            Calification = 4.5f
        };

        // Act
        bookHub.AddBook(book);

        // Assert
        Assert.Contains(book, bookHub.Books);
        
        bookHub.DeleteBook("Test Book");
    }

    [Fact]
    public void DeleteBook_ShouldRemoveBookFromList()
    {
        // Arrange
        var bookHub = new BookHub();
        var book = new Book
        {
            Title = "Test Book",
            ReleaseYear = 2021,
            Duration = 120,
            Genres = new List<string> { "Fiction" },
            Language = "English",
            Summary = "A test book",
            Calification = 4.5f
        };
        bookHub.AddBook(book);

        // Act
        var result = bookHub.DeleteBook("Test Book");

        // Assert
        Assert.True(result);
        Assert.DoesNotContain(book, bookHub.Books);
    }

    [Fact]
    public void UpdateBook_ShouldUpdateExistingBook()
    {
        // Arrange
        var bookHub = new BookHub();
        var book = new Book
        {
            Title = "Original Book",
            ReleaseYear = 2020,
            Duration = 100,
            Genres = new List<string> { "Drama" },
            Language = "English",
            Summary = "Original summary",
            Calification = 3.0f
        };
        bookHub.AddBook(book);

        var updatedBook = new Book
        {
            Title = "Updated Book",
            ReleaseYear = 2021,
            Duration = 110,
            Genres = new List<string> { "Thriller" },
            Language = "French",
            Summary = "Updated summary",
            Calification = 4.0f
        };

        // Act
        var result = bookHub.UpdateBook("Original Book", updatedBook);

        // Assert
        Assert.True(result);
        Assert.Contains(updatedBook, bookHub.Books);
        
        bookHub.DeleteBook("Updated Book");
    }

    [Fact]
    public void GetByTitle_ShouldReturnCorrectBook()
    {
        // Arrange
        var bookHub = new BookHub();
        var book = new Book
        {
            Title = "Test Book",
            ReleaseYear = 2021,
            Duration = 120,
            Genres = new List<string> { "Fiction" },
            Language = "English",
            Summary = "A test book",
            Calification = 4.5f
        };
        bookHub.AddBook(book);

        // Act
        var result = bookHub.GetByTitle("Test Book");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(book.Title, result.Title);
        bookHub.DeleteBook("Test Book");
    }

    [Fact]
    public void GetAll_ShouldReturnAllBooks()
    {
        // Arrange
        var bookHub = new BookHub();
        var book1 = new Book
        {
            Title = "Test Book 1",
            ReleaseYear = 2021,
            Duration = 120,
            Genres = new List<string> { "Fiction" },
            Language = "English",
            Summary = "A test book",
            Calification = 4.5f
        };
        var book2 = new Book
        {
            Title = "Test Book 2",
            ReleaseYear = 2021,
            Duration = 120,
            Genres = new List<string> { "Fiction" },
            Language = "English",
            Summary = "A test book",
            Calification = 4.5f
        };
        bookHub.AddBook(book1);
        bookHub.AddBook(book2);

        // Act
        var result = bookHub.GetAll();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(book1, result);
        Assert.Contains(book2, result);
    }
}
