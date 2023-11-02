namespace Domain.DTOs;

public class CommentDto
{
    public string postName { get; set; }
    public string username { get; set; }
    public string text { get; set; }

    public CommentDto(string postName, string username, string text)
    {
        this.postName = postName;
        this.username = username;
        this.text = text;
    }
}