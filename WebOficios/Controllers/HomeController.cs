using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        // metodo de la guia pag8y14
        public IActionResult Index(string buscarTexto)
        {
            var consulta = from p in _context.Publicaciones
                           select p;

            if (!string.IsNullOrEmpty(buscarTexto))
            {
                consulta = from p in _context.Publicaciones
                           where p.Categoria.Contains(buscarTexto)
                              || p.Localidad.Contains(buscarTexto)
                              || p.Titulo.Contains(buscarTexto)
                           select p;
            }

            var listaPublicaciones = consulta.ToList();
            return View(listaPublicaciones);
        }

        public IActionResult Detalle(int id)
        {
            var publicacion = (from p in _context.Publicaciones
                               where p.Id == id
                               select p).FirstOrDefault();

            return View(publicacion);
        }

        [HttpPost]
        public IActionResult EnviarPresupuesto(int publicacionId, string detalleDelTrabajo)
        {
            TempData["MensajeExito"] = "La solicitud de presupuesto fue enviada con exito!";
            return RedirectToAction("Index");
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Publicacion nuevaPublicacion)
        {
            _context.Publicaciones.Add(nuevaPublicacion);
            _context.SaveChanges();

            TempData["MensajeExito"] = "¡Tu publicación fue creada y guardada en la base de datos!";
            return RedirectToAction("Index");
        }

    }

}
