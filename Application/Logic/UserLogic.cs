using Application.IDao;
using Application.ILogic;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existing = await userDao.GetByUsernameAsync(dto.UserName, dto.Email);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        User toCreate = new User(dto.Email, dto.Password, dto.UserName);
        
        User created = await userDao.CreateAsync(toCreate);
        
        return created;
    }
    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.UserName;
        string email = userToCreate.Email;
        string password = userToCreate.Password;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");

        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");
        if(email.Length < 6)
            throw new Exception("Email must be longer than 6 characters!");
        if(password.Length < 7)
            throw new Exception("Password must be longer than 7 characters!");
    }
    
}