namespace GEPDA_API.Models.Request
{
    public class AspiranteEntrevistaRequest
    {
        public int Id { get; set; }
        public int IdAspirante { get; set; }
        public int? IdEntrevista { get; set; }
        public double? Nota { get; set; }
        public string? FechaEntre { get; set; }
    }
}
