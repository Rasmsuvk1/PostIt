using Application.IDao;
using Application.ILogic;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class PostLogic:IPostLogic
{
    
    private readonly IPostDao postDao;
    
    public PostLogic(IPostDao postDao)
    {
        this.postDao = postDao;
    }
    
    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        
        ValidateData(dto);
        Post toCreate = new Post(new User{username = dto.Username}, dto.Title,dto.Body);
        
        Post created = await postDao.CreateAsync(toCreate);
        
        return created;
    }

    public async Task<Comment> AddCommentAsync(CommentDto dto)
    {
        Comment created = await postDao.AddCommentAsync(dto);
        return created;
    }

    public async Task<Post> DeleteAsync(string userToDelete)
    {
        Post postToDelete = await postDao.DeleteAsync(userToDelete);
        return postToDelete;
    }

    private static void ValidateData(PostCreationDto postToCreate)
    {
        if(postToCreate.Body.Length < 1)
            throw new Exception("No message!");
        if(postToCreate.Title.Length < 1)
            throw new Exception("No Title!");
        if(postToCreate.Username.Length < 1)
            throw new Exception("Error concerning validation of username!");
        
    }
}