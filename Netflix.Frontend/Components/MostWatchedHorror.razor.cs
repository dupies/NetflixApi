using Microsoft.AspNetCore.Components;
using Netflix.Frontend.Models;
using Netflix.Frontend.Services.Interfaces;
using Netflix.Frontend.Shared;

namespace Netflix.Frontend.Components;

public class MostWatchedHorrorBase : PageBase
{
    public MostWatchedHorrorBase()
    {
        TopRatedMovies = new List<MovieResponse>();
        HorrorMovies = new List<MovieResponse>();
    }

    [Inject]
    public IMoviesDataService MoviesDataService { get; set; }
    
    public List<MovieResponse> TopRatedMovies { get; set; }
    public List<MovieResponse> HorrorMovies { get; set; }


    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        var result = await MoviesDataService.GetAllMovies();
        var movies = result.ToList();

        HorrorMovies = result.Where(am => am.Genre_ids.Contains(12)).OrderByDescending(m => m.Popularity).Take(7).ToList();
        TopRatedMovies = result.OrderByDescending(m => m.Vote_average).Take(7).ToList();

    }

    protected void Play(int movieId)
    {
        Navigation.NavigateTo($"/play/{movieId}");
    }
}
