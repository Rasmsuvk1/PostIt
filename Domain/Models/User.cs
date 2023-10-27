namespace Domain;

public class User
{
    public string email { get; set; }
    public string password { get; set; }
    public string username { get; set; }

    public User(string email, string password, string username)
    {
        this.email = email;
        this.password = password;
        this.username = username;
    }
}