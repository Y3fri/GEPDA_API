namespace GEPDA_API.Models.Request
{
    public class UniversidadSedeRequest
    {
        public int SedId { get; set; }
        public int SedUniversidad { get; set; }
        public string SedNombre { get; set; } = null!;
        public string SedEmail { get; set; } = null!;
        public string SedDireccion { get; set; } = null!;
        public string SedTelefono { get; set; } = null!;
    }
}
