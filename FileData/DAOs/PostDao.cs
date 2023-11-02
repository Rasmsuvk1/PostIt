using Application.IDao;
using Domain;
using Domain.DTOs;

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

    public Task<Comment> AddCommentAsync(CommentDto dto)
    {
        Post? post = context.Posts.FirstOrDefault(post => post.Title == dto.postName);
        if (post == null)
        {
            throw new Exception($"Post with name {dto.postName} does not exist!");
        }

        Comment comment = new Comment(dto.username, dto.text);
        post.addComment(comment);
        context.SaveChanges();
        return Task.FromResult(comment);
    }
}