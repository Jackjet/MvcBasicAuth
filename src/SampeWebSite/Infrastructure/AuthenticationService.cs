using MvcBasicAuth;

namespace SampeWebSite.Infrastructure
{
    public class AuthenticationService : IHttpBasicAuthentication
    {
        private const string Username = "user";

        private const string Password = "password";

        public string Realm => "MvcBasicAuth Sample Application";

        public bool Authenticate(string username, string password)
        {
            return username == Username && password == Password;
        }
    }
}