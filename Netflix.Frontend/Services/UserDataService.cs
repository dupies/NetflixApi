using Netflix.Frontend.Models;
using Netflix.Frontend.Services.Interfaces;

namespace Netflix.Frontend.Services;

public class UserDataService : BaseDataService, IUserDataService
{
    public UserDataService(HttpClient httpClient, IConfiguration configuration) 
        : base(httpClient, configuration)
    {
    }

    protected string ApiPath => "api/users";

    public async Task<UserResponse> GetUser(int id)
    {
        var user = await GetJsonResults<UserResponse>($"{ApiPath}/{id}");

        return user;
    }

    public async Task<IEnumerable<UserWatchHistoriesResponse>> GetUserWatchHistories(int id)
    {
        var userWatchHistory = await GetJsonResults<IEnumerable<UserWatchHistoriesResponse>>($"{ApiPath}/{id}/watch");

        return userWatchHistory;
    }
}
