﻿using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Movies;
using NetflixApi.Domain.Movies.MovieHistories;
using NetflixApi.Domain.Shared;

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
        MovieHistories = new List<MovieHistory>();
        Movies = new List<Movie>();
    }

    public int[] FavouriteTVShow { get; set; }
    public int[] FavouriteMovie { get; set; }
    public Name Name { get; set; }
    public AvatarId AvatarId { get; set; }
    public ImageUrl ImageUrl { get; set; }
    public virtual ICollection<MovieHistory> MovieHistories { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }

}
