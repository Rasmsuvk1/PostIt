namespace BalzorPost.Data;

public static class UserInformation
{

    private static string Username = null;
    private static int AuthenticationLvl = 0;

    public static void SetUserInfo(string username, int authenticationLvl)
    {
        Username = username;
        AuthenticationLvl = authenticationLvl;

    }


}