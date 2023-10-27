using Domain;

namespace Application.IDao;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    
}