using SistemaDePeliculasCodigo.Entities;

namespace SistemaDeLibrosCodigo;

public class BookHub
{
    public List<Book> Books { get; set; }
    private readonly string filePath = "books.txt";

    public BookHub()
    {
        Books = new List<Book>();
        LoadBooksFromFile(); 
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
        SaveBooksToFile();
    }

    public bool DeleteBook(string title)
    {
        var book = Books.FirstOrDefault(m => m.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase));
        var result = Books.Remove(book);
        if (result) SaveBooksToFile();
        return result;
    }

    public bool UpdateBook(string title, Book book)
    {
        var bookByTitle = Books.FirstOrDefault(m => m.Title == title);
        
        if (bookByTitle is null) return false;
        
        var index = Books.IndexOf(bookByTitle);
        
        if (index == -1) return false;
        
        Books[index] = book;
        SaveBooksToFile();
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
    
    private void SaveBooksToFile()
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var book in Books)
            {
                // Escribir cada libro en una línea con un formato específico
                var genres = string.Join(",", book.Genres); // Convertir la lista de géneros a una cadena separada por comas
                writer.WriteLine($"{book.Title}|{book.ReleaseYear}|{book.Duration}|{genres}|{book.Language}|{book.Summary}|{book.Calification}");
            }
        }
    }
    
    private void LoadBooksFromFile()
    {
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
        }

        using (var reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var data = line.Split('|');
                if (data.Length >= 4)
                {
                    var genres = data[3].Split(',').ToList();
                    var book = new Book
                    {
                        Title = data[0],
                        ReleaseYear = int.Parse(data[1]),
                        Duration = int.Parse(data[2]),
                        Genres = genres,
                        Language = data[4],
                        Summary = data[5],
                        Calification = float.Parse(data[6])
                    };
                    Books.Add(book);
                }
            }
        }
    }
}