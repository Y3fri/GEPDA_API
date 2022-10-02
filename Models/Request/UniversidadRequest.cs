namespace GEPDA_API.Models.Request
{
    public class UniversidadRequest
    {
        public int UniId { get; set; }
        public int UniMunicipio { get; set; }
        public string UniNombre { get; set; } = null!;
        public string UniEmailPrincipal { get; set; } = null!;
        public string UniDireccionPrincipal { get; set; } = null!;
        public string UniTelefonoPrincipal { get; set; } = null!;
        public string UniLogo { get; set; } = null!;
        
    }
}
