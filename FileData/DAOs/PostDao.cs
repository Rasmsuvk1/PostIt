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
    public async Task<Post> CreateAsync(Post post)
    {
        
        int id = 1;
        
        
        if ( context.Posts.Any())
        {
            id = context.Posts.Max(t => t.Id);
            id++;
        }

        post.Id = id;
        context.Posts.Add(post);
        context.SaveChanges();

        return post;
        
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

    public Task<Post> DeleteAsync(string userToDelete)
    {
        Post? post =context.Posts.FirstOrDefault(post => post.Title == userToDelete);
        if (post == null)
        {
            throw new Exception($"Post with name {userToDelete} does not exist!");
        }

        context.Posts.Remove(post);
        context.SaveChanges();
        return Task.FromResult(post);
    }

    public Task<ICollection<Post>> GetAllPosts(GetPostDto dto)
    {
        if (dto.ReturnId() == null)
        {
            return Task.FromResult(context.Posts);
        }

        Post? post = context.Posts.FirstOrDefault(post => post.Id == dto.ReturnId());
        ICollection<Post> returnPost = new List<Post>();
        if (post!= null)
        {
            returnPost.Add(post);  
        }
        return Task.FromResult(returnPost);
    }
}