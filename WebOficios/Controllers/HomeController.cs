using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebOficios.Models;

namespace WebOficios.Controllers
{
    public class HomeController : Controller
    {
        // CAMBIO AQUÍ: Nombre sin guiones bajos
        private readonly OrtNuevasTecnologias1Context _context;

        // CAMBIO AQUÍ: Nombre sin guiones bajos
        public HomeController(OrtNuevasTecnologias1Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Consultamos la tabla de profesionales e incluimos su categoría
            var listaProfesionales = await _context.Profesionales.Include(p => p.Categoria).ToListAsync();
            return View(listaProfesionales);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
