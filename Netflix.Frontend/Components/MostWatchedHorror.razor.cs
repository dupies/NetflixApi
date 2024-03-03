using Microsoft.AspNetCore.Components;
using Netflix.Frontend.Models;
using Netflix.Frontend.Services.Interfaces;
using NetflixApi.Api.Services;

namespace Netflix.Frontend.Components;

public class MostWatchedHorrorBase : ComponentBase
{
    public MostWatchedHorrorBase()
    {
        Movies = new List<MovieResponse>();
        HorrorMovies = new List<MovieResponse>();
    }

    [Inject]
    public IMoviesDataService MoviesDataService { get; set; }
    public List<MovieResponse> Movies { get; set; }
    public List<MovieResponse> HorrorMovies { get; set; }

    public string BaseUrl { get; set; } = "http://image.tmdb.org/t/p/original/";

    protected override async Task OnInitializedAsync()
    {
        var result = await MoviesDataService.GetAllMovies();
        Movies = result.ToList();

        HorrorMovies = Movies.Where(am => am.Genre_ids.Contains(12)).OrderByDescending(m => m.Popularity).Take(7).ToList();
    }

}
