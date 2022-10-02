using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class DepartamentoMunicipio
    {
        public DepartamentoMunicipio()
        {
            InformacionUniversidads = new HashSet<InformacionUniversidad>();
            SedeProgramaAspirantes = new HashSet<SedeProgramaAspirante>();
        }

        public int MunId { get; set; }
        public int MunDep { get; set; }
        public string MunCodigoDane { get; set; } = null!;
        public string MunNombre { get; set; } = null!;

        public virtual PaisDepartamento MunDepNavigation { get; set; } = null!;
        public virtual ICollection<InformacionUniversidad> InformacionUniversidads { get; set; }
        public virtual ICollection<SedeProgramaAspirante> SedeProgramaAspirantes { get; set; }
    }
}
