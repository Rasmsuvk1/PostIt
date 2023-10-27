namespace Domain;

public class Post
{
    private int Id { get; set; }
    private User user { get; set; }
    private string title { get; set; }
    private string body{ get; set; }

    public Post(int id, User user, string title, string body)
    {
        Id = id;
        this.user = user;
        this.title = title;
        this.body = body;
    }
}