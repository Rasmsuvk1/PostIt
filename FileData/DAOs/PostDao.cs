using Application.IDao;
using Domain;

namespace FileData.DAOs;

public class PostDao : IPostDao
{
    
    public Task<Post> CreateAsync(Post post)
    {
        throw new NotImplementedException();
    }
}