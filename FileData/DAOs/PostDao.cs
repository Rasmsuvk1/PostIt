using Application.IDao;
using Domain;

namespace FileData.DAOs;

public class PostDao : IPostDao
{
    private readonly FileContext context;
    
    
    public PostDao(FileContext context)
    {
        this.context = context;
    }
    public Task<Post> CreateAsync(Post post)
    {
        
        Console.WriteLine(post.Title +post.Body+ post.User.username);
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(t => t.Id);
            id++;
        }

        post.Id = id;
        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
        
    }
}