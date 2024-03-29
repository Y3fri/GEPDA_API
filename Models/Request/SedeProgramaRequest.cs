﻿namespace GEPDA_API.Models.Request
{
    public class SedeProgramaRequest
    {
        public int ProId { get; set; }
        public int ProUniversidad { get; set; }
        public int ProSede { get; set; }
        public string ProNombre { get; set; } = null!;
        public string ProDescripcion { get; set; } = null!;
        public int ProEstado { get; set; }
    }
}
