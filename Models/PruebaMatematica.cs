using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class PruebaMatematica
    {
        public int PmId { get; set; }
        public string? PmTitulo { get; set; }
        public string? PmTexto { get; set; }
        public string? PmPregunta { get; set; }
        public string? PmOpcionA { get; set; }
        public string? PmOpcionB { get; set; }
        public string? PmOpcionC { get; set; }
        public string? PmOpcionD { get; set; }
        public string? PmImagen { get; set; }
        public int? PmEstado { get; set; }

        public virtual Estado? PmEstadoNavigation { get; set; }
    }
}
