using System;
using System.Net.Http.Json;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Core.Handlers;

public class AtlasHandlerEcartToken : DelegatingHandler
{
    private readonly TokenProvider _tokenP;

    public AtlasHandlerEcartToken(TokenProvider tokenP)
    {
        _tokenP = tokenP;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        
        var r = await _tokenP.GetTokenAsync();

        request.Headers.Add("Cookie", "lang=eng");
        request.Headers.Add("Authorization", r);



        var response = await base.SendAsync(request, cancellationToken);

        
        return response;
    }
}


public class Authorization
{
    public string token { get; set; } = null!;
}


public class TokenProvider
{

    private readonly IConfiguration _config;
    private readonly IHttpClientFactory _httpClientFactory;

    private readonly HttpClient _httpClient;

    public TokenProvider(IConfiguration config, IHttpClientFactory clientFactory)
    {
        _config = config;
        _httpClientFactory = clientFactory;

        _httpClient = _httpClientFactory.CreateClient("TokenProvider");
    }

    public async Task<string> GetTokenAsync()
    {
        string publicKey = _config["ECart:Keys:Pub"] ?? throw new Exception();
        string privateKey = _config["ECart:Keys:Prv"] ?? throw new Exception();
        string url = _config["ECart:Urls:dev"] ?? throw new Exception();


        string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{publicKey}:{privateKey}"));

        _httpClient.DefaultRequestHeaders.Add("Cookie", "lang=eng");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {auth}");
        _httpClient.BaseAddress = new Uri(url);

        var s = await _httpClient.PostAsync("", null);

        var token = await s.Content.ReadFromJsonAsync<Authorization>() ?? throw new Exception();
        
        return token.token;




    }

}