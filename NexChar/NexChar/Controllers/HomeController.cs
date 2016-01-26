using System.Linq;
using System.Web.Mvc;
using NexCharCore;

namespace NexChar.Controllers
{
    public class HomeController : Controller
    {
        NexCharContext context = new NexCharContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Nexus LARP";

            return View();
        }
    }
}
