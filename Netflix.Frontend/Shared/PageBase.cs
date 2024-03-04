using Microsoft.AspNetCore.Components;
using Netflix.Frontend.Models;
using Netflix.Frontend.Services.Interfaces;

namespace Netflix.Frontend.Shared;

public class PageBase : ComponentBase
{
    [Inject]
    public NavigationManager Navigation { get; set; }
    [Inject]
    public IUserDataService UserDataService { get; set; }

    public UserResponse User { get; set; }
    public int CurentUserId { get; set; } = 0;
    public string BaseUrl { get; set; } = "http://image.tmdb.org/t/p/original/";


    protected override async Task OnInitializedAsync()
    {
        User = await UserDataService.GetUser(CurentUserId);
    }
}
