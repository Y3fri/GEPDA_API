using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class PaisDepartamento
    {
        public PaisDepartamento()
        {
            DepartamentoMunicipios = new HashSet<DepartamentoMunicipio>();
        }

        public int DepId { get; set; }
        public int DepPais { get; set; }
        public string DepCodigoDane { get; set; } = null!;
        public string DepNombre { get; set; } = null!;

        public virtual Pai DepPaisNavigation { get; set; } = null!;
        public virtual ICollection<DepartamentoMunicipio> DepartamentoMunicipios { get; set; }
    }
}
