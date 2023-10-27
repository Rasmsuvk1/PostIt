using Application.ILogic;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class PostLogic:IPostLogic
{
    public Task<Post> CreateAsync(PostCreationDto userToCreate)
    {
        throw new NotImplementedException();
    }
}