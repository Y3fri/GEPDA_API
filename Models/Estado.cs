using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Entrevista = new HashSet<Entrevistum>();
            InformacionUniversidads = new HashSet<InformacionUniversidad>();
            PruebaIa = new HashSet<PruebaIum>();
            PruebaMatematicas = new HashSet<PruebaMatematica>();
            SedeProgramaAspirantes = new HashSet<SedeProgramaAspirante>();
            SedeProgramas = new HashSet<SedePrograma>();
            SsoUsuarios = new HashSet<SsoUsuario>();
            UniversidadSedes = new HashSet<UniversidadSede>();
        }

        public int EstId { get; set; }
        public string? EstNombre { get; set; }

        public virtual ICollection<Entrevistum> Entrevista { get; set; }
        public virtual ICollection<InformacionUniversidad> InformacionUniversidads { get; set; }
        public virtual ICollection<PruebaIum> PruebaIa { get; set; }
        public virtual ICollection<PruebaMatematica> PruebaMatematicas { get; set; }
        public virtual ICollection<SedeProgramaAspirante> SedeProgramaAspirantes { get; set; }
        public virtual ICollection<SedePrograma> SedeProgramas { get; set; }
        public virtual ICollection<SsoUsuario> SsoUsuarios { get; set; }
        public virtual ICollection<UniversidadSede> UniversidadSedes { get; set; }
    }
}
