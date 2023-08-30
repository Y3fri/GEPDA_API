using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class SedePrograma
    {
        public SedePrograma()
        {
            Entrevista = new HashSet<Entrevistum>();
            SedeProgramaAspirantes = new HashSet<SedeProgramaAspirante>();
            SsoUsuarios = new HashSet<SsoUsuario>();
        }

        public int ProId { get; set; }
        public int ProUniversidad { get; set; }
        public int ProSede { get; set; }
        public string ProNombre { get; set; } = null!;
        public string ProDescripcion { get; set; } = null!;
        public int? ProEstado { get; set; }

        public virtual Estado? ProEstadoNavigation { get; set; }
        public virtual UniversidadSede ProSedeNavigation { get; set; } = null!;
        public virtual InformacionUniversidad ProUniversidadNavigation { get; set; } = null!;
        public virtual ICollection<Entrevistum> Entrevista { get; set; }
        public virtual ICollection<SedeProgramaAspirante> SedeProgramaAspirantes { get; set; }
        public virtual ICollection<SsoUsuario> SsoUsuarios { get; set; }
    }
}
