using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class DniTipo
    {
        public DniTipo()
        {
            SedeProgramaAspirantes = new HashSet<SedeProgramaAspirante>();
        }

        public int DniId { get; set; }
        public string DniNombre { get; set; } = null!;
        public string DniDescripcion { get; set; } = null!;

        public virtual ICollection<SedeProgramaAspirante> SedeProgramaAspirantes { get; set; }
    }
}
