namespace GEPDA_API.Models.Request
{
    public class PaisDepartamentoRequest
    {
        public int DepId { get; set; }
        public int DepPais { get; set; }
        public string DepCodigoDane { get; set; } = null!;
        public string DepNombre { get; set; } = null!;
    }
}
