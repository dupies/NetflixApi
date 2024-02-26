using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Shared;

namespace NetflixApi.Domain.Users;

public class User : Entity
{
    public User(int id)
        : base(id)
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
    }

    public Name Name { get; set; }
    public AvatarId AvatarId { get; set; }
    public ImageUrl ImageUrl { get; set; }
}
