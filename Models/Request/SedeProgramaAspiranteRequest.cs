namespace GEPDA_API.Models.Request
{
    public class SedeProgramaAspiranteRequest
    {
        public int AspId { get; set; }
        public int AspUniversidad { get; set; }
        public int AspSede { get; set; }
        public int AspPrograma { get; set; }
        public int AspDni { get; set; }
        public int AspMunicipio { get; set; }
        public string AspDocumento { get; set; } = null!;
        public string AspNombres { get; set; } = null!;
        public string AspApellidos { get; set; } = null!;
        public string AspTelefono { get; set; } = null!;
        public string AspBarrio { get; set; } = null!;
        public string AspDireccion { get; set; } = null!;
        public double? AspPromedioPruebaIa { get; set; }
        public double? AspPromedioEntrevista { get; set; }
        public double? AspPromedioPrueba2 { get; set; }
        public double? AspNotaFinal { get; set; }
        public int? AspEstado { get; set; }

    }
}
