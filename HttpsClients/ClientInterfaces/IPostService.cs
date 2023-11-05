using Domain;


namespace HttpsClients.ClientInterfaces;

public interface IPostService
{
    Task<IEnumerable<Post>> Get();
}