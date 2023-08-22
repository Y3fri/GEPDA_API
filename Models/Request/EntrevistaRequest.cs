namespace GEPDA_API.Models.Request
{
    public class EntrevistaRequest
    {
        public int EntId { get; set; }
        public int? EntUniversidad { get; set; }
        public int? EntSede { get; set; }
        public int? EntPrograma { get; set; }
        public string? EntNombre { get; set; }
        public string? EntDescripcion { get; set; }
        public int? EntEstado { get; set; }
    }
}
