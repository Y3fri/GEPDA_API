using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class AspiranteEntrevistum
    {
        public int Id { get; set; }
        public int IdAspirante { get; set; }
        public int? IdEntrevista { get; set; }
        public double? Nota { get; set; }

        public virtual SedeProgramaAspirante IdAspiranteNavigation { get; set; } = null!;
        public virtual Entrevistum? IdEntrevistaNavigation { get; set; }
    }
}
