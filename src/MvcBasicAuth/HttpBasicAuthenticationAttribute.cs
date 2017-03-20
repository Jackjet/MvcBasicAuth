//
// Protocol details: https://en.wikipedia.org/wiki/Basic_access_authentication
//

using System;
using System.Text;
using System.Web.Mvc;

namespace MvcBasicAuth
{
    public class HttpBasicAuthenticationAttribute : FilterAttribute, IAuthorizationFilter
    {
        private const string Prefix = "Basic";

        private const string Authorization = "Authorization";

        private const string Authenticate = "WWW-Authenticate";

        private const string Realm = @"Basic realm=""{0}""";

        // TempData key to store authenticated username
        public static readonly string Username = "MvcBasicAuthUsername";

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var authService = DependencyResolver.Current.GetService<IHttpBasicAuthentication>();
            if (authService == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            var req = filterContext.HttpContext.Request;
            var res = filterContext.HttpContext.Response;
            var token = req.Headers[Authorization];

            if (token?.StartsWith(Prefix) == true)
            {
                token = token.Substring(6);     // "Basic XXXXXXXXXX" -> "XXXXXXXXXX"
                var decoded = Encoding.Default.GetString(Convert.FromBase64String(token));
                var credentials = decoded.Split(':');

                if (credentials.Length == 2 
                    && authService.Authenticate(credentials[0], credentials[1]))
                {
                    filterContext.Controller.TempData[Username] = credentials[0];
                    return;
                }
            }

            res.AddHeader(Authenticate, string.Format(Realm, authService.Realm));
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}
