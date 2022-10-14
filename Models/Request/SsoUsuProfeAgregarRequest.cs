namespace GEPDA_API.Models.Request
{
    public class SsoUsuProfeAgregarRequest
    {
        public int UsuPId { get; set; }
        public int UsuPSede { get; set; }
        public int UsuPPrograma { get; set; }
        public string? UsuPNombre { get; set; }
        public string? UsuPApellido { get; set; }
        public string UsuPEmail { get; set; } = null!;
        public string? UsuPDocumento { get; set; }
        public string UsuPTelefono { get; set; } = null!;
        public string? UsuPNickname { get; set; }
        public string? UsuPClave { get; set; }
    }
}
