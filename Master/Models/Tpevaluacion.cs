using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EvalCore.Models
{
    public partial class Tpevaluacion
    {
        //public Tpevaluacion()
        //{
        //    Evaluaciodetalle = new HashSet<Evaluaciodetalle>();
        //}

        public int Id { get; set; }
        public string Descripcion { get; set; }

        //public virtual ICollection<Evaluaciodetalle> Evaluaciodetalle { get; set; }
    }
}
