using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class PruebaIum
    {
        public int IaId { get; set; }
        public string? IaTitulo { get; set; }
        public string? IaTexto { get; set; }
        public string? IaPregunta { get; set; }
        public string? IaOpcionA { get; set; }
        public string? IaOpcionB { get; set; }
        public string? IaOpcionC { get; set; }
        public string? IaOpcionD { get; set; }
        public string? IaImagen { get; set; }
        public string? IaAudio { get; set; }
        public string? IaRespuesta { get; set; }
        public int? IaEstado { get; set; }

        public virtual Estado? IaEstadoNavigation { get; set; }
    }
}
