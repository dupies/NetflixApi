using AutoMapper;
using NetflixApi.Application.Abstractions.Messaging;
using NetflixApi.Domain.Abstractions;
using NetflixApi.Domain.Movies;
using Serilog;

namespace NetflixApi.Application.Movies.GetMovies;

internal sealed class GetMovieQueryHandler : IQueryHandler<GetMovieQuery, MovieResponse>
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public GetMovieQueryHandler(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    public async Task<Result<MovieResponse>> Handle(GetMovieQuery request, CancellationToken cancellationToken)
    {
        Log.Information("Getting Movie with Id {Id}", request);

        var result = await _movieRepository.GetByIdAsync(request.TVShowId, cancellationToken);
        if (result != null)
        {
            var response = _mapper.Map<MovieResponse>(result);
            //var response = new MovieResponse(
            //    result.Id,
            //    result.Adult,
            //    result.Backdrop_path.Value,
            //    result.Genre_ids,
            //    result.Original_language.Value,
            //    result.Original_title.Value,
            //    result.Overview.Value,
            //    result.Popularity.Value,
            //    result.Poster_path.Value,
            //    result.Release_date.Value,
            //    result.Title.Value,
            //    result.Video,
            //    result.Vote_average.Value,
            //    result.Vote_count.Value);

            return response;
        }
        else
        {
            Log.Information("Movie with Id {Id} does not exists", request);
            return Result.Failure<MovieResponse>(MovieErrors.NotFound);
        }
    }
}
