using Domain;
using Domain.DTOs;


namespace HttpsClients.ClientInterfaces;

public interface IPostService
{
    Task<IEnumerable<Post>> Get();
    Task<Post> CreatePostAsync(PostCreationDto dto);

    Task<Comment> CreateCommentAsync(CommentDto dto);


}