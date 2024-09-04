using SistemaDeLibrosCodigo;
using SistemaDePeliculasCodigo.Entities;

namespace TestProject1;

 public class BookHubTests
    {
        private readonly BookHub _bookHub;

        public BookHubTests()
        {
            // Inicializa un MovieHub vacío antes de cada prueba.
            _bookHub = new BookHub();
        }

        [Fact]
        public void AddMovie_ShouldAddMovieSuccessfully()
        {
            // Arrange
            var movie = new Book("Batman", "Director1", 2024, 130, "Acción", 
                "Español", "Movie about meh", 9.4f, new List<string> { "Actor1", "Actor2" });

            // Act
            _bookHub.AddBook(movie);

            // Assert
            var result = _bookHub.GetByTitle("Batman");
            Assert.NotNull(result);
            Assert.Equal("Batman", result.Title);
        }

        [Fact]
        public void GetMovieByTitle_ShouldReturnCorrectMovie()
        {
            // Arrange
            var movie = new Book("Batman", "Director1", 2024, 130, "Acción", 
                "Español", "Movie about meh", 9.4f, new List<string> { "Actor1", "Actor2" });
            _bookHub.AddMovie(movie);

            // Act
            var result = _bookHub.GetByTitle("Batman");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Batman", result.Title);
        }

        [Fact]
        public void UpdateMovie_ShouldUpdateMovieSuccessfully()
        {
            // Arrange
            var movie = new Book("Batman", "Director1", 2024, 130, "Acción", 
                "Español", "Movie about meh", 9.4f, new List<string> { "Actor1", "Actor2" });
            _bookHub.AddMovie(movie);

            var updatedMovie = new Book("Batman", "Director Updated", 2025, 150, "Acción", 
                "Inglés", "Updated Movie", 8.5f, new List<string> { "Actor3", "Actor4" });

            // Act
            var isUpdated = _bookHub.UpdateBook("Batman", updatedMovie);

            // Assert
            Assert.True(isUpdated);
            var result = _bookHub.GetByTitle("Batman");
            Assert.Equal("Director Updated", result.Director);
            Assert.Equal(2025, result.ReleaseYear);
        }

        [Fact]
        public void DeleteMovie_ShouldRemoveMovieSuccessfully()
        {
            // Arrange
            var movie = new Book("Batman", "Director1", 2024, 130, "Acción", 
                "Español", "Movie about meh", 9.4f, new List<string> { "Actor1", "Actor2" });
            _bookHub.AddMovie(movie);

            // Act
            var isDeleted = _bookHub.DeleteMovie("Batman");

            // Assert
            Assert.True(isDeleted);
            Assert.Null(_bookHub.GetByTitle("Batman"));
        }

        [Fact]
        public void GetAllMovies_ShouldReturnAllMovies()
        {
            // Arrange
            var movie1 = new Book("Batman", "Director1", 2024, 130, "Acción", 
                "Español", "Movie about meh", 9.4f, new List<string> { "Actor1", "Actor2" });
            var movie2 = new Book("Superman", "Director2", 2023, 140, "Aventura", 
                "Inglés", "Movie about Superman", 8.8f, new List<string> { "Actor3", "Actor4" });
            _bookHub.AddMovie(movie1);
            _bookHub.AddMovie(movie2);

            // Act
            var allMovies = _bookHub.GetAll();

            // Assert
            Assert.Equal(2, allMovies.Count);
        }
    }