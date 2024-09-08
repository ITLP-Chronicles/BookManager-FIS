using SistemaDeLibrosCodigo;
using SistemaDePeliculasCodigo.Entities;

var books = new BookHub();

while (true)
{
    Console.Clear();
    Console.WriteLine("Sistema de Libros"); 
    Console.WriteLine("---------------------");
    Console.WriteLine("1.- Listar todas los libros");
    Console.WriteLine("2.- Mostrar un libro por su nombre");
    Console.WriteLine("3.- Añadir libro");
    Console.WriteLine("4.- Actualizar libro");
    Console.WriteLine("5.- Eliminar libros");
    Console.WriteLine("6.- Salir");
    Console.Write("Ingrese la opción que desee ejecutar: ");
    var optionNotParsed = Console.ReadLine();

    if (int.TryParse(optionNotParsed, out int option))
    {
        Console.Clear();
        switch (option)
        {
            case 1:
            {
                ListAllBooks(ref books);
                break;
            }
            
            case 2:
            {
                ShowBookByTitle(ref books);
                break;
            }
            
            case 3:
            {
                CreateBook(ref books);
                break;
            }

            case 4:
            {
                UpdateBook(ref books);
                break;
            }

            case 5:
            {
                DeleteBook(ref books);
                break;
            }

            case 6:
            {
                Console.WriteLine("Gracias por usar el software");
                return;
            }
            
            default:
            {
                Console.WriteLine("Elige una opción valida");
                break;
            }
        }
    }
    Console.WriteLine("Presione enter para continuar");
    Console.ReadKey();
}

static void ListAllBooks(ref BookHub books)
{

    var booksToShow = books.GetAll();
    foreach (var book in booksToShow)
    {
       
        Console.WriteLine("----------------");
        Console.WriteLine($"Titulo: {book.Title}");
        Console.WriteLine($"Fecha de estreno: {book.ReleaseYear}");
        Console.WriteLine($"Paginas: {book.Duration}");
        Console.WriteLine($"Generos: {string.Join(", ",book.Genres)}");
        Console.WriteLine($"Idioma: {book.Language}");
        Console.WriteLine($"Sinopsis: {book.Summary}");
        Console.WriteLine($"Calificación: {book.Calification}");
        Console.WriteLine("----------------");
    }
}

static void ShowBookByTitle(ref BookHub books)
{
    Console.Write("Escriba el nombre exacto del libro a buscar: ");
    var name = Console.ReadLine();
    var book = books.GetByTitle(name);
    if (book is null)
    {
        Console.WriteLine($"El libro con el nombre {name} no ha sido encontrado");
        return;
    }

    Console.WriteLine("----------------");
    Console.WriteLine($"Titulo: {book.Title}");
    Console.WriteLine($"Fecha de estreno: {book.ReleaseYear}");
    Console.WriteLine($"Paginas: {book.Duration}");
    Console.WriteLine($"Generos: {string.Join(", ", book.Genres)}");
    Console.WriteLine($"Idioma: {book.Language}");
    Console.WriteLine($"Sinopsis: {book.Summary}");
    Console.WriteLine($"Calificación: {book.Calification}");
    Console.WriteLine("----------------");
}

static void CreateBook(ref BookHub books)
{
    Console.Write("Ingrese el titulo: ");
    var title = Console.ReadLine();
    var existBook = books.GetByTitle(title);
    if (existBook is not null)
    {
        Console.Write($"El libro con el titulo {title} ya existe en el sistema");
        return;
    }
    Console.Write("Ingrese el año de estreno: ");
    if (!int.TryParse(Console.ReadLine(), out int year))
    {
        Console.WriteLine("Ingrese un año valido");
        return;
    }
    Console.Write("Ingrese las paginas: ");
    if (!int.TryParse(Console.ReadLine(), out int pages))
    {
        if (pages <= 0)
        {
            Console.WriteLine("Ingrese una cantidad de paginas mayor a 0");
            return;
        }

        Console.WriteLine("Ingrese una cantidad de paginas valida");
        return;
    }
    Console.Write("Ingrese los generos separados por una coma (ejemplo: accion, comedia): ");
    var genresString = Console.ReadLine();
    List<string> genres = genresString.Split(", ").ToList();
    Console.Write("Ingrese el idioma: ");
    var language = Console.ReadLine();
    Console.Write("Ingrese la sinopsis: ");
    var summary = Console.ReadLine();
    Console.Write("Ingrese la calificación del 1 al 10: ");
    if (!float.TryParse(Console.ReadLine(), out float calification))
    {
        if (calification < 0 || calification > 10)
        {
            Console.WriteLine("Ingrese una calificación mayor a 1 y menor a 10");
            return;
        }
        Console.WriteLine("Ingrese una calificación valida");
        return;
    }

    var book = new Book(title, year, pages,
        genres, language, summary, calification);

    if (string.IsNullOrWhiteSpace(title) || 
        year <= 0 || pages <= 0 || genres.Count == 0 ||
        string.IsNullOrWhiteSpace(language) || string.IsNullOrWhiteSpace(summary) ||
        calification <= 0)
    {
        Console.WriteLine("Uno o más parámetros del libro son inválidos.");
        return;
    }
                
    books.AddBook(book);
    Console.WriteLine("\nLibro agregado correctamente");
}

static void UpdateBook(ref BookHub books)
{
    Console.Write("Ingrese el titulo del libro a modificar: ");
    var title = Console.ReadLine();
                
    var existbook = books.GetByTitle(title);
    if (existbook is null)
    {
        Console.WriteLine($"El libro con el titulo {title} no existe en el sistema");
        return;
    }
    
    Console.Write("Ingrese el nuevo año de estreno: ");
    if (!int.TryParse(Console.ReadLine(), out int year))
    {
        Console.WriteLine("Ingrese un año valido");
        return;
    }
    Console.Write("Ingrese la nueva cantidad de paginas: ");
    if (!int.TryParse(Console.ReadLine(), out int pages))
    {
        if (pages <= 0)
        {
            Console.WriteLine("Ingrese una cantidad de paginas mayor a 0");
            return;
        }

        Console.WriteLine("Ingrese una cantidad de paginas valida");
        return;
    }
    Console.Write("Ingrese los nuevos generos: ");
    var genresString = Console.ReadLine();
    List<string> genres = genresString.Split(", ").ToList();
    Console.Write("Ingrese el nuevo idioma: ");
    var language = Console.ReadLine();
    Console.Write("Ingrese la nueva sinopsis: ");
    var summary = Console.ReadLine();
    Console.Write("Ingrese la nueva calificación: ");
    if (!int.TryParse(Console.ReadLine(), out int calification))
    {
        if (calification < 0 || calification > 10)
        {
            Console.WriteLine("Ingrese una calificación mayor a 1 y menor a 10");
            return;
        }
        Console.WriteLine("Ingrese una calificación valida");
        return;
    }
    Console.Write("Ingrese los nuevos actores separados por una coma (ej: Andrew Garfield, Tom holland): ");
    var actorsString = Console.ReadLine();
    var actors = actorsString.Split(',').ToList();

    var book = new Book(title, year, pages,
        genres, language, summary, calification);
                
    if (string.IsNullOrWhiteSpace(title) || 
        year <= 0 || pages <= 0 || genres.Count == 0||
        string.IsNullOrWhiteSpace(language) || string.IsNullOrWhiteSpace(summary) ||
        calification <= 0)
    {
        Console.WriteLine("Uno o más parámetros de la libro son inválidos.");
        return;
    }
                
    if (books.UpdateBook(title, book))
    {
        Console.WriteLine("\nLibro modificada correctamente");
        return;
    }

    Console.WriteLine("\nEl libro no fue actualizado correctamente");
}

static void DeleteBook(ref BookHub books)
{
    Console.Write("Ingrese el titulo del libro a eliminar: ");
    var title = Console.ReadLine();
    if (books.DeleteBook(title))
    {
        Console.WriteLine("Libro eliminada correctamente");
        return;
    }
                
    Console.WriteLine($"El libro con el titulo {title} no fue encontrado");
}
