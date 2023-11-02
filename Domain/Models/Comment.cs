namespace Domain;
// this doesnt have a dto, since the DTO would be the same as the Comment class.
public class Comment
{
    public string username { get; set; }
    public string text { get; set; }

    public Comment(string username, string text)
    {
        this.username = username;
        this.text = text;
    }
}