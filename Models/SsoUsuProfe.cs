using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class SsoUsuProfe
    {
        public int UsuPId { get; set; }
        public int UsuPUniversidad { get; set; }
        public int UsuPSede { get; set; }
        public int UsuPPrograma { get; set; }
        public string? UsuPNombre { get; set; }
        public string? UsuPApellido { get; set; }
        public string UsuPEmail { get; set; } = null!;
        public string? UsuPDocumento { get; set; }
        public string UsuPTelefono { get; set; } = null!;
        public string? UsuPNickname { get; set; }
        public string? UsuPClave { get; set; }
        public int? UsuPEstado { get; set; }

        public virtual Estado? UsuPEstadoNavigation { get; set; }
        public virtual SedePrograma UsuPProgramaNavigation { get; set; } = null!;
        public virtual UniversidadSede UsuPSedeNavigation { get; set; } = null!;
        public virtual InformacionUniversidad UsuPUniversidadNavigation { get; set; } = null!;
    }
}
