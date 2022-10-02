using System;
using System.Collections.Generic;

namespace GEPDA_API.Models
{
    public partial class SsoRol
    {
        public SsoRol()
        {
            SsoUsuarios = new HashSet<SsoUsuario>();
        }

        public int RolId { get; set; }
        public string RolNombre { get; set; } = null!;
        public string RolDescripcion { get; set; } = null!;

        public virtual ICollection<SsoUsuario> SsoUsuarios { get; set; }
    }
}
