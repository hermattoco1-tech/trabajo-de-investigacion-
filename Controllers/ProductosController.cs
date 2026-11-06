using CatalogoProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProductos.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string categoria)
        {
            var productos = _context.Productos.AsQueryable();

            if (!string.IsNullOrEmpty(categoria))
            {
                productos = productos.Where(p =>
                    p.Categoria.Contains(categoria));
            }

            return View(productos.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();

                TempData["Mensaje"] =
                    "Producto registrado correctamente.";

                return RedirectToAction("Index");
            }

            return View(producto);

        }

        public IActionResult Resumen()
        {
            var resumen = _context.Productos
                .GroupBy(x => x.Categoria)
                .Select(x => new ResumenCategoria
                {
                    Categoria = x.Key,
                    Cantidad = x.Count()
                })
                .ToList();

            return View(resumen);

        }

    }
}