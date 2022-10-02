using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class Pai
    {
        public Pai()
        {
            PaisDepartamentos = new HashSet<PaisDepartamento>();
        }

        public int PaiId { get; set; }
        public string PaiNombre { get; set; } = null!;

        public virtual ICollection<PaisDepartamento> PaisDepartamentos { get; set; }
    }
}
