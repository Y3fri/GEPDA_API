namespace GEPDA_API.Models.Request
{
    public class SedeProgramaRequest
    {
        public int ProId { get; set; }
        public int ProSede { get; set; }
        public string ProNombre { get; set; } = null!;
    }
}
