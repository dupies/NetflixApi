using AutoMapper;
using NetflixApi.Application.Movies.GetMovies;
using NetflixApi.Application.WatchHistories.GetUserWatchHistories;
using NetflixApi.Domain.Movies;
using NetflixApi.Domain.WatchHistories;

namespace NetflixApi.Application.Abstractions.MappingConfigurations;

public class ApplicationMappings : Profile
{
    public ApplicationMappings()
    {
        this.ConfigureMappings();
    }

    private void ConfigureMappings()
    {
        CreateMap<WatchHistory, UserWatchHistoriesResponse>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.ShowId, opt => opt.MapFrom(src => src.ShowId))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie))
            .ForMember(dest => dest.TVShow, opt => opt.MapFrom(src => src.TVShow));

        CreateMap<Movie, MovieResponse>()
        .ForCtorParam(nameof(MovieResponse.Id), opt => opt.MapFrom(src => src.Id))
        .ForCtorParam(nameof(MovieResponse.Adult), opt => opt.MapFrom(src => src.Adult))
        .ForCtorParam(nameof(MovieResponse.Backdrop_path), opt => opt.MapFrom(src => src.Backdrop_path.Value)) 
        .ForCtorParam(nameof(MovieResponse.Genre_ids), opt => opt.MapFrom(src => src.Genre_ids.ToList()))
        .ForCtorParam(nameof(MovieResponse.Original_language), opt => opt.MapFrom(src => src.Original_language.Value)) 
        .ForCtorParam(nameof(MovieResponse.Original_title), opt => opt.MapFrom(src => src.Original_title.Value)) 
        .ForCtorParam(nameof(MovieResponse.Overview), opt => opt.MapFrom(src => src.Overview.Value))
        .ForCtorParam(nameof(MovieResponse.Popularity), opt => opt.MapFrom(src => src.Popularity.Value))
        .ForCtorParam(nameof(MovieResponse.Poster_path), opt => opt.MapFrom(src => src.Poster_path.Value)) 
        .ForCtorParam(nameof(MovieResponse.Release_date), opt => opt.MapFrom(src => src.Release_date.Value)) 
        .ForCtorParam(nameof(MovieResponse.Title), opt => opt.MapFrom(src => src.Title.Value)) 
        .ForCtorParam(nameof(MovieResponse.Video), opt => opt.MapFrom(src => src.Video))
        .ForCtorParam(nameof(MovieResponse.Vote_average), opt => opt.MapFrom(src => src.Vote_average.Value)) 
        .ForCtorParam(nameof(MovieResponse.Vote_count), opt => opt.MapFrom(src => src.Vote_count.Value));
    }
}
