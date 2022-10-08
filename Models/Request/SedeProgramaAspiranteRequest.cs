﻿namespace GEPDA_API.Models.Request
{
    public class SedeProgramaAspiranteRequest
    {
        public int AspId { get; set; }
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
        public double? AspNota1 { get; set; }
        public double? AspNota2 { get; set; }
        public double? AspNota3 { get; set; }
        public double? AspNota4 { get; set; }
        public double? AspNota5 { get; set; }
        public double? AspPromedio { get; set; }
        public DateTime? AspFecha { get; set; }
        public TimeSpan? AspHora { get; set; }
    }
}
