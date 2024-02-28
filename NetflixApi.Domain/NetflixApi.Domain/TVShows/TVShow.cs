using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Shared;

namespace NetflixApi.Domain.TVShows;

public class TVShow : Entity
{
    public TVShow()
    {
        
    }
    public TVShow(
        int id, 
        bool adult, 
        string backdrop_path, 
        int[] genre_ids, 
        string[] origin_country, 
        string original_language, 
        string original_name, 
        string overview, 
        double popularity, 
        string poster_path, 
        DateOnly first_air_date, 
        string name, 
        double vote_average, 
        int vote_count)
        : base(id)
    {
        Adult = adult;
        Backdrop_path = new(backdrop_path);
        Genre_ids = genre_ids;
        Origin_country = origin_country;
        Original_language = new(original_language);
        Original_name = new(original_name);
        Overview = new(overview);
        Popularity = new(popularity);
        Poster_path = new(poster_path);
        First_air_date = new(first_air_date);
        Name = new(name);
        Vote_average = new(vote_average);
        Vote_count = new(vote_count);
    }

    public bool Adult { get; set; }
    public Backdrop_path Backdrop_path { get; set; }
    public int[] Genre_ids { get; set; }
    public string[] Origin_country { get; set; }
    public Original_language Original_language { get; set; }
    public Name Original_name { get; set; }
    public Overview Overview { get; set; }
    public Popularity Popularity { get; set; }
    public Poster_path Poster_path { get; set; }
    public First_air_date First_air_date { get; set; }
    public Name Name { get; set; }
    public Vote_average Vote_average { get; set; }
    public Vote_count Vote_count { get; set; }
}