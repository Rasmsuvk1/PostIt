using Domain;
using Domain.DTOs;

namespace Application.ILogic;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto userToCreate);
    
}