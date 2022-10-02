namespace GEPDA_API.Models.Request
{
    public class DepartamentoMunicipioRequest
    {
        public int MunId { get; set; }
        public int MunDep { get; set; }
        public string MunCodigoDane { get; set; } = null!;
        public string MunNombre { get; set; } = null!;

    }
}
