using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Movies;
using NetflixApi.Domain.Shared;
using NetflixApi.Domain.TVShows;
using NetflixApi.Domain.WatchHistories;

namespace NetflixApi.Domain.Users;

public class User : Entity
{
    public User()
    {
        
    }
    public User(
        int id,
        string name, 
        string avatarId, 
        string imageUrl)
        : base(id)
    {
        Name = new(name);
        AvatarId = new (avatarId);
        ImageUrl = new (imageUrl);
        Movies = new List<Movie>();
        TVShows = new List<TVShow>();
        FavouriteTVShow = new List<int>();
        FavouriteMovie = new List<int>();
        WatchHistories = new List<WatchHistory>();
    }

    public List<int> FavouriteTVShow { get; set; }
    public List<int> FavouriteMovie { get; set; }
    public Name Name { get; set; }
    public AvatarId AvatarId { get; set; }
    public ImageUrl ImageUrl { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
    public virtual ICollection<TVShow> TVShows { get; set; }

    public virtual ICollection<WatchHistory> WatchHistories { get; set; }
}
