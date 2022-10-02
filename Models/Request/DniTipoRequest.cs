namespace GEPDA_API.Models.Request
{
    public class DniTipoRequest
    {
        public int DniId { get; set; }
        public string DniNombre { get; set; } = null!;
        public string DniDescripcion { get; set; } = null!;
    }
}
