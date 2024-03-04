using Netflix.Frontend.Models;
using Netflix.Frontend.Services;
using Netflix.Frontend.Shared;

namespace Netflix.Frontend.Components;

public class UserWatchHistoryBase : PageBase

{
    public UserWatchHistoriesResponse WatchHistories { get; set; }
    public List<MovieResponse> WatchedMovies { get; set; }

    protected override async Task OnInitializedAsync()
    {
        //await base.OnInitializedAsync();
        //var result = await UserDataService.GetUserWatchHistories(User.Id);
        //WatchedMovies = result.Where(h => h.Type == ShowType.Movie).Select(h => h.Movie).ToList();

        //WatchedMovies = histories.Where

    }
}
