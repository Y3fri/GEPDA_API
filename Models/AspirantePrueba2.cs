using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class AspirantePrueba2
    {
        public int? IdAspirante { get; set; }
        public int? IdPruebaMate { get; set; }
        public int? Puntos { get; set; }
        public string? Respuesta { get; set; }

        public virtual SedeProgramaAspirante? IdAspiranteNavigation { get; set; }
        public virtual Prueba2? IdPruebaMateNavigation { get; set; }
    }
}
