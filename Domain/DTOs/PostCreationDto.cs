namespace Domain.DTOs;

public class PostCreationDto
{
    
    public string Username { get; set; }
    
    public string Title { get; set; }
    
    public string Body { get; set; }

    public PostCreationDto(string username, string title, string body)
    {
        Username = username;
        Title = title;
        Body = body;
        
    }
}