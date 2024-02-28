using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Movies.MovieHistories;
using NetflixApi.Domain.Shared;
using NetflixApi.Domain.Users;

namespace NetflixApi.Domain.Movies;
public class Movie : Entity
{
    public Movie()
    {
    }
    public Movie(
        int id,
        bool adult,
        string backdrop_path,
        int[] genre_ids,
        string original_language,
        string original_title,
        string overview,
        double popularity,
        string poster_path,
        DateOnly release_date,
        string title,
        bool video,
        double vote_average,
        int vote_count)
        : base(id)
    {
        Adult = adult;
        Backdrop_path = new(backdrop_path);
        Genre_ids = genre_ids;
        Original_language = new(original_language);
        Original_title = new(original_title);
        Overview = new(overview);
        Popularity = new(popularity);
        Poster_path = new(poster_path);
        Release_date = new(release_date);
        Title = new(title);
        Video = video;
        Vote_average = new(vote_average);
        Vote_count = new(vote_count);
        MovieHistories = new List<MovieHistory>();
        Users = new List<User>();
    }

    public bool Adult { get; set; }
    public Backdrop_path Backdrop_path { get; set; }
    public int[] Genre_ids { get; set; }
    public Original_language Original_language { get; set; }
    public Original_title Original_title { get; set; }
    public Overview Overview { get; set; }
    public Popularity Popularity { get; set; }
    public Poster_path Poster_path { get; set; }
    public Release_date Release_date { get; set; }
    public Title Title { get; set; }
    public bool Video { get; set; }
    public Vote_average Vote_average { get; set; }
    public Vote_count Vote_count { get; set; }
    public virtual ICollection<MovieHistory> MovieHistories { get; set; }
    public virtual ICollection<User> Users { get; set; }
}