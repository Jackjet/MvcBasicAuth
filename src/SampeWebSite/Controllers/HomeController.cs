using System.Web.Mvc;
using MvcBasicAuth;

namespace SampeWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("Public content");
        }

        [HttpBasicAuthentication]
        public ActionResult Account()
        {
            var username = TempData[HttpBasicAuthenticationAttribute.Username];
            return Content($"Username = {username}");
        }
    }
}