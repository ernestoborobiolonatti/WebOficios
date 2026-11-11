using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebOficios.Models;

namespace WebOficios.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrtNuevasTecnologias1Context _context;

        
        public HomeController(OrtNuevasTecnologias1Context context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index(string buscarTexto)
        {
            
            var consulta = _context.Publicaciones.AsQueryable();

            
            if (!string.IsNullOrEmpty(buscarTexto))
            {
                consulta = consulta.Where(p =>
                    p.Categoria.Contains(buscarTexto) ||
                    p.Localidad.Contains(buscarTexto) ||
                    p.Titulo.Contains(buscarTexto)
                );
            }

           
            var listaReal = await consulta.ToListAsync();
            return View(listaReal);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Detalle(int id)
        {
            var publicacion = await _context.Publicaciones.FindAsync(id);
            return View(publicacion);
        }

        
        [HttpPost]
        public IActionResult EnviarPresupuesto(int publicacionId, string detalleDelTrabajo)
        {
            TempData["MensajeExito"] = "¡Tu solicitud de presupuesto fue enviada con éxito!";
            return RedirectToAction("Index");
        }
    }

}
