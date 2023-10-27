using Application.IDao;
using Application.ILogic;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class PostLogic:IPostLogic
{
    
    private readonly IPostDao postDao;
    
    public Task<Post> CreateAsync(PostCreationDto userToCreate)
    {
        throw new NotImplementedException();
    }

    private static void ValidateData(UserCreationDto userToCreate)
    {
        
    }
}