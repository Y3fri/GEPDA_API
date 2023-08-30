using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class InformacionUniversidad
    {
        public InformacionUniversidad()
        {
            Entrevista = new HashSet<Entrevistum>();
            SedeProgramas = new HashSet<SedePrograma>();
            SsoUsuarios = new HashSet<SsoUsuario>();
            UniversidadSedes = new HashSet<UniversidadSede>();
        }

        public int UniId { get; set; }
        public int UniMunicipio { get; set; }
        public string UniNombre { get; set; } = null!;
        public string UniEmailPrincipal { get; set; } = null!;
        public string UniDireccionPrincipal { get; set; } = null!;
        public string UniTelefonoPrincipal { get; set; } = null!;
        public string UniLogo { get; set; } = null!;
        public int? UniEstado { get; set; }

        public virtual Estado? UniEstadoNavigation { get; set; }
        public virtual DepartamentoMunicipio UniMunicipioNavigation { get; set; } = null!;
        public virtual ICollection<Entrevistum> Entrevista { get; set; }
        public virtual ICollection<SedePrograma> SedeProgramas { get; set; }
        public virtual ICollection<SsoUsuario> SsoUsuarios { get; set; }
        public virtual ICollection<UniversidadSede> UniversidadSedes { get; set; }
    }
}
