using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EvalCore.Models
{
    public partial class DepartamentoProyectos 
    {
        public DepartamentoProyectos()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int KeyDepartamentoProyecto { get; set; }
        public decimal DirId { get; set; }
        public string Nombre { get; set; }
        public string DptCentroCosto { get; set; }
        public string Observacion { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
