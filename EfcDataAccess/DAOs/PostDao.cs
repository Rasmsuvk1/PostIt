using Application.IDao;
using Domain;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostDao : IPostDao
{
    private readonly DBContext context;

    public PostDao(DBContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        try
        {
            User? user = context.Users.FirstOrDefault(u => u.username.Equals(post.Username));
            // Insert a post for the new user
            if (user != null)
            {
                var aPost = new Post(user, post.Title, post.Body);
                EntityEntry<Post> newPost = await context.Posts.AddAsync(aPost);
                await context.SaveChangesAsync();  
                return newPost.Entity;
            }
        }
        catch (Exception ex)
        {
            // Access the inner exception for more details
            Exception innerException = ex.InnerException;

            // Now you can log or display the details of the inner exception
            Console.WriteLine("Inner Exception Details: " + innerException.Message);
        }

        return null;
    }

    public async Task<Comment> AddCommentAsync(CommentDto dto)
    {
        // Use FirstOrDefaultAsync for asynchronous query
        Post? post = await context.Posts.FirstOrDefaultAsync(p => p.Title.Equals(dto.postName));

        if (post == null)
        {
            // Use a more specific exception or create a custom exception
            throw new Exception($"Post with title '{dto.postName}' does not exist!");
        }
        Comment newComment = new Comment(dto.username, dto.text);
        post.addComment(newComment);
        
        context.Posts.Update(post);
        await context.SaveChangesAsync();
        return newComment;
    }

    public async Task<Post> DeleteAsync(string userToDelete)
    {
        Post? post = context.Posts.FirstOrDefault(post => post.Title == userToDelete);
        if (post == null)
        {
            throw new Exception($"Post with name {userToDelete} does not exist!");
        }

        context.Posts.Remove(post);
        await context.SaveChangesAsync();
        return post;
    }

    public async Task<ICollection<Post>> GetAllPosts(GetPostDto dto)
    {
        if (dto.ReturnId() == null)
        {
            List<Post> result = await context.Posts.ToListAsync();
            return result;
        }
        
        Post? post = await context.Posts.Include(p => p.comments)
            .FirstOrDefaultAsync(post => post.Id == dto.ReturnId());
        ICollection<Post> returnPost = new List<Post>();
        if (post!= null)
        {
            returnPost.Add(post);  
        }
        return returnPost;
    }
}