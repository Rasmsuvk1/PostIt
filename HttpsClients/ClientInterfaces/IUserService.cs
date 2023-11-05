using Domain;
using Domain.DTOs;

namespace HttpsClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserCreationDto dto);

    Task<ReturnLoginDto> Login(LoginDto dto);

}
