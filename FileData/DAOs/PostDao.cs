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
        
        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
        
    }
}