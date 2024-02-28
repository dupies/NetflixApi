using NetflixApi.Domain.Abstractions;

namespace NetflixApi.Domain.Movies.MovieHistories;

public interface IMovieHistoryRepository
{
    Task Add(MovieHistory entity);
}
