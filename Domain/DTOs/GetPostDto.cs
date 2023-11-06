namespace Domain.DTOs;

public class GetPostDto
{
    private int? Id = null;

    public void SetId(int? id)
    {
        Id = id;
    }

    public int? ReturnId()
    {
        return Id;
    }
    
}