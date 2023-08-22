using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class AspirantePruebamate
    {
        public int? IdAspirante { get; set; }
        public int? IdPruebaMate { get; set; }
        public string? RespuestaCorrecta { get; set; }
        public int? Puntos { get; set; }

        public virtual SedeProgramaAspirante? IdAspiranteNavigation { get; set; }
        public virtual PruebaMatematica? IdPruebaMateNavigation { get; set; }
    }
}
