using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Movies;
using NetflixApi.Domain.Shared;
using NetflixApi.Domain.TVShows;
using NetflixApi.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetflixApi.Domain.WatchHistories;
public class WatchHistory : Entity
{
    public WatchHistory()
    {
        Date = new(DateTime.UtcNow);
    }

    public WatchHistory(
        int userId,
        int showId,
        ShowType type)
    {
        Random random = new Random();
        Id = random.Next(1, 1001);
        UserId = userId;
        ShowId = showId;
        Type = type;
        Date = new(DateTime.UtcNow);
    }
    public int UserId { get; set; }
    public int ShowId { get; set; }
    public WatchDate Date { get; set; }
    public ShowType Type { get; set; }

    public virtual User User { get; set; }
    public virtual Movie Movie { get; set; }
    public virtual TVShow TVSHow { get; set; }
    public string PartitionKey { get => this.ShowId.ToString(); }
}