using Domain;
using Domain.DTOs;

namespace Application.ILogic;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto userToCreate);

    Task<Comment> AddCommentAsync(CommentDto dto);
    
    Task<Post> DeleteAsync(string userToDelete);
}