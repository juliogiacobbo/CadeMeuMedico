using System.Web.Mvc;

namespace CadeMeuMedico.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        public ActionResult Login()
        {
            ViewBag.Title = "Seja bem vindo(a)";
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
