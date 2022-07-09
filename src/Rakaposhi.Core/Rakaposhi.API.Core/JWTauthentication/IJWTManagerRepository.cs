namespace Rakaposhi.API.Core.JWTauthentication
{
    public interface IJWTManagerRepository
    {
        Token Authenticate(string user);
    }
}
