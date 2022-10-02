using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class ProgramaCriterio
    {
        public int CriId { get; set; }
        public int CriPrograma { get; set; }
        public string CriNombre { get; set; } = null!;
        public string CriDescripcion { get; set; } = null!;

        public virtual SedePrograma CriProgramaNavigation { get; set; } = null!;
    }
}
