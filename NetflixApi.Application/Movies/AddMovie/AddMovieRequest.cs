namespace NetflixApi.Application.Movies.AddMovie;

public record AddMovieRequest(
        int Id,
        bool Adult,
        string Backdrop_path,
        int[] Genre_ids,
        string Original_language,
        string Original_title,
        string Overview,
        double Popularity,
        string Poster_path,
        DateOnly Release_date,
        string Title,
        bool Video,
        double Vote_average,
        int Vote_count
    );