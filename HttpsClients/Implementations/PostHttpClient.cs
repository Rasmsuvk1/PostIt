using System.Net.Http.Json;
using System.Text.Json;
using Application.IDao;
using Domain;
using Domain.DTOs;
using HttpsClients.ClientInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

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

    public async Task<Post> CreatePostAsync(PostCreationDto dto)
    {
        
        HttpResponseMessage response = await client.PostAsJsonAsync("/Post", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Post post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
        
    }

    public async Task<Comment> CreateCommentAsync(CommentDto dto)
    {
        HttpResponseMessage response = await client.PutAsJsonAsync("/Post", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Comment comment = JsonSerializer.Deserialize<Comment>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return comment;
    }

    public async void DeletePostAsync(DeletePostDto dto)
    {
        HttpResponseMessage response = await client.DeleteAsync($"/Post?postToDelete={dto.titleName}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
    }
}

