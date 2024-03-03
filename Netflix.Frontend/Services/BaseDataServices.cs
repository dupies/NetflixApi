using Netflix.Frontend.Models;
using Newtonsoft.Json;

namespace NetflixApi.Api.Services;

public abstract class BaseDataService
{
    #region [ CTor ]
    public BaseDataService(HttpClient httpClient, IConfiguration configuration)
    {
        this._httpClient = httpClient;
        this.BaseApiPath = configuration.GetValue<string>("WebApiUrl");
    }
    #endregion

    #region [ Constants ]
    public const string JSON_MEDIA_TYPE = "application/json";
    #endregion

    #region [ Fields ]
    protected readonly HttpClient _httpClient;
    #endregion

    #region [ Properties ]
    protected string BaseApiPath { get; }
    #endregion

    protected StringContent PrepareJsonPayload(object payloadContentObject)
    {
        var serializedPayload = JsonConvert.SerializeObject(payloadContentObject);
        var result = new StringContent(serializedPayload, System.Text.Encoding.UTF8, JSON_MEDIA_TYPE);

        return result;
    }

    protected async Task<string> GetStringResult(string requestUrl)
    {
        var response = await _httpClient.GetAsync(BaseApiPath + requestUrl);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();

        return result;
    }

    protected async Task<T> GetJsonResults<T>(string requestUrl)
    {
        var response = await _httpClient.GetStringAsync(BaseApiPath + requestUrl);

        var x = JsonConvert.DeserializeObject<ICollection<MovieResponse>>(response);

        var result = JsonConvert.DeserializeObject<T>(response);

        return result;

    }

    protected async Task<T> SendAsync<T>(string requestUrl, HttpMethod httpMethod)
    {
        var reqMsq = new HttpRequestMessage(httpMethod, BaseApiPath + requestUrl);
        var response = await _httpClient.SendAsync(reqMsq);
        //
        response.EnsureSuccessStatusCode();

        var respStream = await response.Content.ReadAsStringAsync();
        T result = JsonConvert.DeserializeObject<T>(respStream);

        return result;
    }
}