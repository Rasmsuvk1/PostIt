namespace Domain.DTOs;

public class DeletePostDto
{
    public string titleName { get; set; }

    public DeletePostDto(string titleName)
    {
        this.titleName = titleName;
    }
}