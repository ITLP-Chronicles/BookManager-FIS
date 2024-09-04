using SistemaDeLibrosCodigo;
using SistemaDePeliculasCodigo.Entities;

namespace TestProject1;

public class BookHubTests
{
    private readonly BookHub _bookHub;

    public BookHubTests()
    {
        _bookHub = new BookHub();
    }

    [Fact]
    public void AddBook_ShouldAddBookSuccessfully()
    {
        // Arrange
        var book = new Book("Batman", 2024, 130, new List<string> { "Acción" }, 
            "Español", "Book about meh", 9.4f);

        // Act
        _bookHub.AddBook(book);

        // Assert
        var result = _bookHub.GetByTitle("Batman");
        Assert.NotNull(result);
        Assert.Equal("Batman", result.Title);
    }

    [Fact]
    public void GetBookByTitle_ShouldReturnCorrectBook()
    {
        // Arrange
        var book = new Book("Batman", 2024, 130, new List<string> { "Acción" }, 
            "Español", "Book about meh", 9.4f);
        _bookHub.AddBook(book);

        // Act
        var result = _bookHub.GetByTitle("Batman");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Batman", result.Title);
    }

    [Fact]
    public void UpdateBook_ShouldUpdateBookSuccessfully()
    {
        // Arrange
        var book = new Book("Batman", 2024, 130, new List<string> { "Acción" }, 
            "Español", "Book about meh", 9.4f);
        _bookHub.AddBook(book);

        var updatedBook = new Book("Batman", 2025, 150, new List<string> { "Acción" }, 
            "Inglés", "Updated Book", 8.5f);

        // Act
        var isUpdated = _bookHub.UpdateBook("Batman", updatedBook);

        // Assert
        Assert.True(isUpdated);
        var result = _bookHub.GetByTitle("Batman");
        Assert.Equal(2025, result.ReleaseYear);
        Assert.Equal(150, result.Duration);
    }

    [Fact]
    public void DeleteBook_ShouldRemoveBookSuccessfully()
    {
        // Arrange
        var book = new Book("Batman", 2024, 130, new List<string> { "Acción" }, 
            "Español", "Book about meh", 9.4f);
        _bookHub.AddBook(book);

        // Act
        var isDeleted = _bookHub.DeleteBook("Batman");

        // Assert
        Assert.True(isDeleted);
        Assert.Null(_bookHub.GetByTitle("Batman"));
    }

    [Fact]
    public void GetAllBooks_ShouldReturnAllBooks()
    {
        // Arrange
        var book1 = new Book("Batman", 2024, 130, new List<string> { "Acción" }, 
            "Español", "Book about meh", 9.4f);
        var book2 = new Book("Superman", 2023, 140, new List<string> { "Aventura" }, 
            "Inglés", "Book about Superman", 8.8f);
        _bookHub.AddBook(book1);
        _bookHub.AddBook(book2);

        // Act
        var allBooks = _bookHub.GetAll();

        // Assert
        Assert.Equal(2, allBooks.Count);
    }
}
