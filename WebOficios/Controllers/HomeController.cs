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

        // metodo que lee desde SQL Server
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
    }
}
