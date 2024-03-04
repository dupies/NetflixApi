using AutoMapper;
using NetflixApi.Application.Abstractions.Messaging;
using NetflixApi.Application.Movies.GetMovies;
using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Movies;
using Serilog;

namespace NetflixApi.Application.Movies.GetAllMovies;

internal sealed class GetAllMoviesQueryHandler : IQueryHandler<GetAllMoviesQuery, ICollection<MovieResponse>>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public GetAllMoviesQueryHandler(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    public async Task<Result<ICollection<MovieResponse>>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        Log.Information("Getting Movie with Id {Id}", request);

        var result = await _movieRepository.GetAll(request.GenreId, cancellationToken);
        if (result != null)
        {
            var response = _mapper.Map <ICollection<MovieResponse>>(result);

            return Result.Success<ICollection<MovieResponse>>(response);
        }
        else
        {
            Log.Information("Movie with Id {Id} does not exists", request);
            return Result.Failure<ICollection<MovieResponse>>(MovieErrors.NotFound);
        }
    }
}
