using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EvalCore.Models
{
    public partial class Ponderacion
    {
        public Ponderacion()
        {
            Pregunta = new HashSet<Pregunta>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Valor { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Pregunta> Pregunta { get; set; }
    }
}
