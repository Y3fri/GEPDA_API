using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class SedeProgramaAspirante
    {
        public SedeProgramaAspirante()
        {
            AspiranteEntrevista = new HashSet<AspiranteEntrevistum>();
        }

        public int AspId { get; set; }
        public int AspUniversidad { get; set; }
        public int AspSede { get; set; }
        public int AspPrograma { get; set; }
        public int AspDni { get; set; }
        public int AspMunicipio { get; set; }
        public string AspDocumento { get; set; } = null!;
        public string AspNombres { get; set; } = null!;
        public string AspApellidos { get; set; } = null!;
        public string AspTelefono { get; set; } = null!;
        public string AspBarrio { get; set; } = null!;
        public string AspDireccion { get; set; } = null!;
        public double? AspPromedioPruebaIa { get; set; }
        public double? AspPromedioEntrevista { get; set; }
        public double? AspPromedioPrueba2 { get; set; }
        public double? AspNotaFinal { get; set; }
        public int? AspEstado { get; set; }

        public virtual DniTipo AspDniNavigation { get; set; } = null!;
        public virtual Estado? AspEstadoNavigation { get; set; }
        public virtual DepartamentoMunicipio AspMunicipioNavigation { get; set; } = null!;
        public virtual SedePrograma AspProgramaNavigation { get; set; } = null!;
        public virtual UniversidadSede AspSedeNavigation { get; set; } = null!;
        public virtual InformacionUniversidad AspUniversidadNavigation { get; set; } = null!;
        public virtual ICollection<AspiranteEntrevistum> AspiranteEntrevista { get; set; }
    }
}
