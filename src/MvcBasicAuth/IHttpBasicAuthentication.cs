namespace MvcBasicAuth
{
    public interface IHttpBasicAuthentication
    {
        string Realm { get; }

        bool Authenticate(string username, string password);
    }
}
