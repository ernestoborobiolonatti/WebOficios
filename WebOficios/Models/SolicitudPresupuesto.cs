namespace WebOficios.Models
{
    public class SolicitudPresupuesto
    {
        public int Id { get; set; }
        public int PublicacionId { get; set; }
        public string EmailCliente { get; set; } = string.Empty;
        public string detalleDelTrabajo { get; set; } = string.Empty;
        public string fechaSolicitud { get; set; } = string.Empty;
        public string horaSolicitud { get; set; } = string.Empty;
        public string detalleRespuesta { get; set; } = string.Empty;
        public double importePresupuesto { get; set; }
        public bool Respondida { get; set; }
    }
}
