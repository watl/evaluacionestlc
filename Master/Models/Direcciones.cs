using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EvalCore.Models
{
    public partial class Direcciones
    {
        public Direcciones() 
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public decimal DirId { get; set; }
        public string DirNombre { get; set; }
        public string DirDescripcion { get; set; }
        public string DirCentroCosto { get; set; }
        public string DirUsuarioAud { get; set; }
        public DateTime? DirFechaAud { get; set; }
        public bool? DirActivo { get; set; }

        public virtual ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
