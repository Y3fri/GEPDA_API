using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class InformacionUniversidad
    {
        public InformacionUniversidad()
        {
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

        public virtual DepartamentoMunicipio UniMunicipioNavigation { get; set; } = null!;
        public virtual ICollection<SsoUsuario> SsoUsuarios { get; set; }
        public virtual ICollection<UniversidadSede> UniversidadSedes { get; set; }
    }
}
