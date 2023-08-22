using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class Entrevistum
    {
        public Entrevistum()
        {
            AspiranteEntrevista = new HashSet<AspiranteEntrevistum>();
        }

        public int EntId { get; set; }
        public int? EntUniversidad { get; set; }
        public int? EntSede { get; set; }
        public int? EntPrograma { get; set; }
        public string? EntNombre { get; set; }
        public string? EntDescripcion { get; set; }
        public int? EntEstado { get; set; }

        public virtual Estado? EntEstadoNavigation { get; set; }
        public virtual SedePrograma? EntProgramaNavigation { get; set; }
        public virtual UniversidadSede? EntSedeNavigation { get; set; }
        public virtual InformacionUniversidad? EntUniversidadNavigation { get; set; }
        public virtual ICollection<AspiranteEntrevistum> AspiranteEntrevista { get; set; }
    }
}
