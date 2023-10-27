namespace Domain.DTOs;

public class PostCreationDto
{
    public int Id { get; }
    
    public int? userId { get; set; }
    
    public string? Title { get; set; }
    
    public string? Body { get; set; }

    public PostCreationDto(int id)
    {
        Id = id;
    }
}