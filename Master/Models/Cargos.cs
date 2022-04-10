using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EvalCore.Models
{
    public partial class Cargos 
    {
        public Cargos()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public decimal CarId { get; set; }
        public string CarNombre { get; set; }
        public string CarDescripcion { get; set; }
        public bool? CarHomologado { get; set; }
        public string CarUsuarioAud { get; set; }
        public DateTime? CarFechaAud { get; set; }

        public virtual ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
