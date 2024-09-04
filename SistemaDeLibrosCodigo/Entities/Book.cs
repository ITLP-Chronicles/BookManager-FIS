namespace SistemaDePeliculasCodigo.Entities;

public class Book
{
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public int Duration { get; set; }
    public List<string> Genres { get; set; }
    public string Language { get; set; }
    public string Summary { get; set; }
    public float Calification { get; set; }

    public Book(string title, int releaseYear, int duration,
        List<string> genre, string language, string summary, 
        float calification)
    {
        Title = title;
        ReleaseYear = releaseYear;
        Duration = duration;
        Genres = genre;
        Language = language;
        Summary = summary;
        Calification = calification;
    }
}