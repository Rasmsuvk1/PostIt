using Domain;
using Domain.DTOs;

namespace Application.IDao;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName, string email);
    Task<ReturnLoginDto> LoginAsync(LoginDto dto);
}