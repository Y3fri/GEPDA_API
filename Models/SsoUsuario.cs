using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class SsoUsuario
    {
        public int UsuId { get; set; }
        public int UsuUniversidad { get; set; }
        public int UsuPrograma { get; set; }
        public int UsuSede { get; set; }
        public int UsuRol { get; set; }
        public string UsuDocumento { get; set; } = null!;
        public string UsuEmail { get; set; } = null!;
        public string UsuNombre { get; set; } = null!;
        public string UsuApellido { get; set; } = null!;
        public string UsuNickname { get; set; } = null!;
        public string UsuClave { get; set; } = null!;
        public int UsuEstado { get; set; }

        public virtual Estado UsuEstadoNavigation { get; set; } = null!;
        public virtual SedePrograma UsuProgramaNavigation { get; set; } = null!;
        public virtual SsoRol UsuRolNavigation { get; set; } = null!;
        public virtual UniversidadSede UsuSedeNavigation { get; set; } = null!;
        public virtual InformacionUniversidad UsuUniversidadNavigation { get; set; } = null!;
    }
}
