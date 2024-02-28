using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Movies;
using NetflixApi.Domain.Shared;
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
    }

    public int[] FavouriteTVShow { get; set; }
    public int[] FavouriteMovie { get; set; }
    public Name Name { get; set; }
    public AvatarId AvatarId { get; set; }
    public ImageUrl ImageUrl { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }

    public virtual ICollection<WatchHistory> WatchHistories { get; set; }
}
