namespace GEPDA_API.Models.Request
{
    public class ProgramaCriterioRequest
    {
        public int CriId { get; set; }
        public int CriSede { get; set; }
        public int CriPrograma { get; set; }
        public string CriNombre { get; set; } = null!;
        public string CriDescripcion { get; set; } = null!;
    }
}
