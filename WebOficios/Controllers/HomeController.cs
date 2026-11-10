using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebOficios.Models;

namespace WebOficios.Controllers
{
    public class HomeController : Controller
    {
        
        private static readonly List<Publicacion> _publicacionesSimuladas = new List<Publicacion>
        {
            new Publicacion
            {
                Titulo = "Instalaciones Eléctricas Mendoza",
                Descripcion = "Cortocircuitos, tableros y mantenimiento residencial las 24 horas.",
                Categoria = "Electricista",
                Localidad = "Caballito",
                CostoServicio = 45000.0
            },
            new Publicacion
            {
                Titulo = "Plomería y Gas Pérez",
                Descripcion = "Reparación de fugas de agua, destapaciones de cañerías e instalación de sanitarios.",
                Categoria = "Plomero",
                Localidad = "Flores",
                CostoServicio = 38000.0
            },
            new Publicacion
            {
                Titulo = "Muebles a Medida Silva",
                Descripcion = "Fabricación, armado y restauración de muebles en maderas macizas.",
                Categoria = "Carpintero",
                Localidad = "Palermo",
                CostoServicio = 60000.0
            }
        };

        // metodo buscarPublicaciones de la clase Marketplace
        public IActionResult Index(string buscarTexto)
        {
            var resultados = _publicacionesSimuladas;

            // filtro dinámico
            if (!string.IsNullOrEmpty(buscarTexto))
            {
                resultados = _publicacionesSimuladas.Where(p =>
                    p.Categoria.Contains(buscarTexto, System.StringComparison.OrdinalIgnoreCase) ||
                    p.Localidad.Contains(buscarTexto, System.StringComparison.OrdinalIgnoreCase) ||
                    p.Titulo.Contains(buscarTexto, System.StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            // devuelve la lista de publicaciones procesada a la pantalla que ve el usuarioo
            return View(resultados);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
