namespace Domain.DTOs;

public class ReturnLoginDto
{
    
    public string username { get; set; }
    public int authenticationLvl { get; set; }

    public ReturnLoginDto(string username, int authenticationLvl)
    {
        this.username = username;
        this.authenticationLvl = authenticationLvl;
    }
}