using System.Web.Mvc;
namespace CasoEstudioProductosMVC5.Controllers { public class HomeController : Controller { public ActionResult Index() { return RedirectToAction("Index", "Productos"); } } }
