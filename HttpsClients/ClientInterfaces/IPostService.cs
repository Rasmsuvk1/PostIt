using Domain;
using Domain.DTOs;


namespace HttpsClients.ClientInterfaces;

public interface IPostService
{
    Task<IEnumerable<Post>> Get(GetPostDto id);
    Task<Post> CreatePostAsync(PostCreationDto dto);

    Task<Comment> CreateCommentAsync(CommentDto dto);

    void DeletePostAsync(DeletePostDto dto);


}