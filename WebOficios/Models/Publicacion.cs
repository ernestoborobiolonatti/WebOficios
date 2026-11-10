namespace WebOficios.Models
{
    public class Publicacion
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Localidad { get; set; } = string.Empty;
        public double CostoServicio { get; set; }
    }
}
