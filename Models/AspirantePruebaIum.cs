using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class AspirantePruebaIum
    {
        public int? IdAspirante { get; set; }
        public int? IdPruebaIa { get; set; }
        public string? Respuesta { get; set; }
        public int? Puntos { get; set; }

        public virtual SedeProgramaAspirante? IdAspiranteNavigation { get; set; }
        public virtual PruebaIum? IdPruebaIaNavigation { get; set; }
    }
}
