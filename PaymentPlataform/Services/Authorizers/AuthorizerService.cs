using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaymentPlataform.Services.Authorizers;

public class AuthorizerService : IAuthorizerService
{
    private readonly HttpClient _httpClient;
    private readonly string? URL;
    private const string STATUS_SUCCESS = "success";

    public AuthorizerService(
        IConfiguration configuration,
        HttpClient httpClient)
    {
        URL = configuration.GetValue<string?>("Authorizer:Url");
        _httpClient = httpClient;
    }

    public async Task<bool> AuthorizerAsync()
    {
        var response = await _httpClient.GetAsync(URL);

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        response.EnsureSuccessStatusCode();

        string content = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<ApiResponse>(content);

        return result?.Status == STATUS_SUCCESS;
    }

    private class ApiResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public DataResponse Data { get; set; }
    }

    private class DataResponse
    {
        [JsonPropertyName("authorization")]
        public bool Authorization { get; set; }
    }
}
