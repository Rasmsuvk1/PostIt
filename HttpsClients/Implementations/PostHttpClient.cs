using System.Net.Http.Json;
using System.Text.Json;
using Application.IDao;
using Domain;
using Domain.DTOs;
using HttpsClients.ClientInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace HttpsClients.Implementations;

[ApiController]
[Route("[controller]")]
public class PostHttpClient : IPostService
{
    private readonly HttpClient client;

    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }


    public async Task<IEnumerable<Post>> Get()
    {
        string uri = "/Post";

        HttpResponseMessage response = await client.GetAsync(uri);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<Post> post = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }

}

