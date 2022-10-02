namespace GEPDA_API.Models.Request
{
    public class SsoRolRequest
    {
        public int RolId { get; set; }
        public string RolNombre { get; set; } = null!;
        public string RolDescripcion { get; set; } = null!;
    }
}
