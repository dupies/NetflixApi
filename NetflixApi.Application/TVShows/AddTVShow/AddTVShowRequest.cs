namespace NetflixApi.Application.TVShows.AddTVShow;

public record AddTVShowRequest(
        int Id,
        bool Adult,
        string Backdrop_path,
        int[] Genre_ids,
        string[] Origin_country,
        string Original_language,
        string Original_name,
        string Overview,
        double Popularity,
        string Poster_path,
        DateOnly First_air_date,
        string Name,
        double Vote_average,
        int Vote_count
    );