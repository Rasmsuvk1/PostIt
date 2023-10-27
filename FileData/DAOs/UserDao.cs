using Application.IDao;
using Domain;

namespace FileData.DAOs;

public class UserDao : IUserDao
{
    
    private readonly FileContext context;

    public UserDao(FileContext context)
    {
        this.context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string userName, string email)
    {

        User? existing = context.Users.FirstOrDefault(user =>
            user.username.Equals(userName)|| user.email.Equals(email)
        );
        return Task.FromResult(existing);

    }
    
}