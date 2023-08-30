using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class UniversidadSede
    {
        public UniversidadSede()
        {
            Entrevista = new HashSet<Entrevistum>();
            SedeProgramaAspirantes = new HashSet<SedeProgramaAspirante>();
            SedeProgramas = new HashSet<SedePrograma>();
            SsoUsuarios = new HashSet<SsoUsuario>();
        }

        public int SedId { get; set; }
        public int SedUniversidad { get; set; }
        public string SedNombre { get; set; } = null!;
        public string SedEmail { get; set; } = null!;
        public string SedDireccion { get; set; } = null!;
        public string SedTelefono { get; set; } = null!;
        public int? SedEstado { get; set; }

        public virtual Estado? SedEstadoNavigation { get; set; }
        public virtual InformacionUniversidad SedUniversidadNavigation { get; set; } = null!;
        public virtual ICollection<Entrevistum> Entrevista { get; set; }
        public virtual ICollection<SedeProgramaAspirante> SedeProgramaAspirantes { get; set; }
        public virtual ICollection<SedePrograma> SedeProgramas { get; set; }
        public virtual ICollection<SsoUsuario> SsoUsuarios { get; set; }
    }
}
