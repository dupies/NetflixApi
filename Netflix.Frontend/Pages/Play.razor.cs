using Microsoft.AspNetCore.Components;
using Netflix.Frontend.Models;
using Netflix.Frontend.Services.Interfaces;
using Netflix.Frontend.Shared;

namespace Netflix.Frontend.Pages;

public class PlayBase : PageBase
{
    [Parameter]
    public int MovieId { get; set; }

    [Inject]
    public IMoviesDataService MoviesDataService { get; set; }
    public MovieResponse Movie { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Movie = await MoviesDataService.GetMovie(MovieId);
    }

}
