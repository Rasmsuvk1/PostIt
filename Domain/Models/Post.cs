using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Post
{
    [Key]
    public int Id { get; set; }

    public string Username{ get; set; }
    public string Title { get; set; }
    public string Body{ get; set; }

    public List<Comment> comments { get; set; } = new List<Comment>();

    public Post( User user, string title, string body)
    {
        Username = user.username;
        Title = title;
        Body = body;
    }
    public Post(){ }
    
    public void addComment(Comment comment)
    {
        comments.Add(comment);
    }
}