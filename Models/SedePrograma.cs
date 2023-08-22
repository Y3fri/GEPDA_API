using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class SedePrograma
    {
        public SedePrograma()
        {
            ProgramaCriterios = new HashSet<ProgramaCriterio>();
            SedeProgramaAspirantes = new HashSet<SedeProgramaAspirante>();
            SsoUsuProves = new HashSet<SsoUsuProfe>();
        }

        public int ProId { get; set; }
        public int ProSede { get; set; }
        public string ProNombre { get; set; } = null!;
        public string ProDescripcion { get; set; } = null!;

        public virtual UniversidadSede ProSedeNavigation { get; set; } = null!;
        public virtual ICollection<ProgramaCriterio> ProgramaCriterios { get; set; }
        public virtual ICollection<SedeProgramaAspirante> SedeProgramaAspirantes { get; set; }
        public virtual ICollection<SsoUsuProfe> SsoUsuProves { get; set; }
    }
}
