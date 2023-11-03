using Domain;
using Domain.DTOs;

namespace Application.ILogic;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate);

    Task<ReturnLoginDto> loginAsync(LoginDto dto);

}