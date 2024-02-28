using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Shared;
using NetflixApi.Domain.Users;

namespace NetflixApi.Domain.Movies.MovieHistories;

public class MovieHistory : Entity
{
    public MovieHistory()
    {
        Date = new(DateTime.UtcNow);
    }

    public MovieHistory(
        int userId,
        int movieId)
    {
        Random random = new Random();
        Id = random.Next(1, 1001);
        UserId = userId;
        MovieId = movieId;
        Date = new(DateTime.UtcNow);
    }
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public int MovieId { get; set; }
    public virtual Movie Movie { get; set; }
    public WatchDate Date { get; set; }
}