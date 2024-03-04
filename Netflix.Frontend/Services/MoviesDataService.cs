
using Netflix.Frontend.Models;
using Netflix.Frontend.Services.Interfaces;

namespace Netflix.Frontend.Services;

public class MoviesDataService : BaseDataService, IMoviesDataService
{
    public MoviesDataService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
    {
    }

    protected string ApiPath => "api/movies";

    public Task<IEnumerable<MovieResponse>> GetAllMovies()
    {
        return this.GetJsonResults<IEnumerable<MovieResponse>>(this.ApiPath);
    }

    public Task<MovieResponse> GetMovie(int id)
    {
        return this.GetJsonResults<MovieResponse>($"{ApiPath}/{id}");
    }
}
