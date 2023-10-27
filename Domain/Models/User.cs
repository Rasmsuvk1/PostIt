namespace Domain;

public class User
{
    private string email { get; set; }
    private string password { get; set; }
    private string username { get; set; }

    public User(string email, string password, string username)
    {
        this.email = email;
        this.password = password;
        this.username = username;
    }
}