using Application.IDao;
using Domain;
using Domain.DTOs;

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

    public Task<ReturnLoginDto> LoginAsync(LoginDto dto)
    {
        User? loggedIn = context.Users.FirstOrDefault(user =>   user.email.Equals(dto.email)|| user.password.Equals(dto.password));
        if (loggedIn == null)
        {
            throw new Exception("No User was found with the information you provided.");
        }
        ReturnLoginDto returnDto = new ReturnLoginDto(loggedIn.username, 1);
        return Task.FromResult(returnDto);

    }
}