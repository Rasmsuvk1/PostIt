using System.ComponentModel.DataAnnotations;

namespace Domain;
public class Comment
{
    [Key]
    public int commentId { get; set; }
    public string username { get; set; }
    public string text { get; set; }

    public Comment(string username, string text)
    {
        this.username = username;
        this.text = text;
    }
    
    public Comment(){}
}