using Application.IDao;
using Domain;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace EfcDataAccess.DAOs;

public class UserDao : IUserDao
{
    private readonly DBContext context;

    public UserDao(DBContext context)
    {
        this.context = context;
    }
    public async Task<User> CreateAsync(User user)
    {
        
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsernameAsync(string userName, string email)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.username.ToLower().Equals(userName.ToLower())
        );
        return existing;
    }

    public async Task<ReturnLoginDto> LoginAsync(LoginDto dto)
    {

        User? loggedIn = await context.Users.FirstOrDefaultAsync(user => user.email.Equals(dto.email) && user.password.Equals(dto.password));
        if (loggedIn == null)
        {
            throw new Exception("No User was found with the information you provided.");
        }
        ReturnLoginDto returnDto = new ReturnLoginDto(loggedIn.username, 1);
        return returnDto;
    }
}