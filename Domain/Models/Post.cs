namespace Domain;

public class Post
{
    private int Id { get; set; }
    private User User { get; set; }
    private string Title { get; set; }
    private string Body{ get; set; }

    public Post(int id, User user, string title, string body)
    {
        Id = id;
        User = user;
        Title = title;
        Body = body;
    }
}