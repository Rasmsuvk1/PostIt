using Domain;
using Domain.DTOs;

namespace Application.IDao;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);

    Task<Comment> AddCommentAsync(CommentDto dto);
    Task<Post> DeleteAsync(string userToDelete);
}