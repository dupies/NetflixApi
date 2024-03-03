using Microsoft.AspNetCore.Components;
using Netflix.Frontend.Components;
using Netflix.Frontend.Models;
using Netflix.Frontend.Services.Interfaces;

namespace Netflix.Frontend.Pages;

public class HomeBase : ComponentBase
{
    [Inject]
    public IMoviesDataService MoviesDataService { get; set; }
    public List<MovieResponse> AllMovies { get; set; }
    public MostWatchedHorror MostWatchedHorror { get; set; } = new MostWatchedHorror();

    protected override async Task OnInitializedAsync()
    {
        var result = await MoviesDataService.GetAllMovies();
        AllMovies = result.ToList();
    }
}
