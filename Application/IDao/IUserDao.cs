using Domain;

namespace Application.IDao;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName, string email);
}