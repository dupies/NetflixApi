using Netflix.Frontend.Models;

namespace Netflix.Frontend.Services.Interfaces;

public interface IUserDataService
{
    Task<UserResponse> GetUser(int id);
    Task<IEnumerable<UserWatchHistoriesResponse>> GetUserWatchHistories(int id);
}
