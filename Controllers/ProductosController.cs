using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CasoEstudioProductosMVC5.Data;
using CasoEstudioProductosMVC5.Models;
namespace CasoEstudioProductosMVC5.Controllers
{
    public class ProductosController : Controller
    {
        private readonly InventarioContext db = new InventarioContext();
        public ActionResult Index(string buscar)
        {
            var productos = db.Productos.AsQueryable();
            if (!string.IsNullOrWhiteSpace(buscar)) productos = productos.Where(p => p.Codigo.Contains(buscar) || p.Nombre.Contains(buscar) || p.Categoria.Contains(buscar));
            ViewBag.Buscar = buscar; return View(productos.OrderBy(p => p.Nombre).ToList());
        }
        public ActionResult Details(int? id) { if (id == null) return new HttpStatusCodeResult(400); var producto = db.Productos.Find(id); return producto == null ? (ActionResult)HttpNotFound() : View(producto); }
        public ActionResult Create() { return View(new Producto()); }
        [HttpPost, ValidateAntiForgeryToken] public ActionResult Create(Producto producto) { Normalizar(producto); if (db.Productos.Any(p => p.Codigo == producto.Codigo)) ModelState.AddModelError("Codigo", "El código ya existe."); if (!ModelState.IsValid) return View(producto); db.Productos.Add(producto); db.SaveChanges(); TempData["Ok"] = "Producto creado correctamente."; return RedirectToAction("Details", new { id = producto.Id }); }
        public ActionResult Edit(int? id) { if (id == null) return new HttpStatusCodeResult(400); var producto = db.Productos.Find(id); return producto == null ? (ActionResult)HttpNotFound() : View(producto); }
        [HttpPost, ValidateAntiForgeryToken] public ActionResult Edit(Producto producto) { Normalizar(producto); if (db.Productos.Any(p => p.Codigo == producto.Codigo && p.Id != producto.Id)) ModelState.AddModelError("Codigo", "El código ya existe."); if (!ModelState.IsValid) return View(producto); db.Entry(producto).State = EntityState.Modified; db.SaveChanges(); TempData["Ok"] = "Producto actualizado correctamente."; return RedirectToAction("Details", new { id = producto.Id }); }
        public ActionResult Delete(int? id) { if (id == null) return new HttpStatusCodeResult(400); var producto = db.Productos.Find(id); return producto == null ? (ActionResult)HttpNotFound() : View(producto); }
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken] public ActionResult DeleteConfirmed(int id) { var producto = db.Productos.Find(id); if (producto != null) { db.Productos.Remove(producto); db.SaveChanges(); TempData["Ok"] = "Producto eliminado correctamente."; } return RedirectToAction("Index"); }
        private static void Normalizar(Producto producto) { producto.Codigo = (producto.Codigo ?? "").Trim().ToUpperInvariant(); producto.Nombre = (producto.Nombre ?? "").Trim(); producto.Categoria = (producto.Categoria ?? "").Trim(); }
        protected override void Dispose(bool disposing) { if (disposing) db.Dispose(); base.Dispose(disposing); }
    }
}
