using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EvalCore.Models
{
    public partial class Pregunta
    {
        //public Pregunta()
        //{
        //    Detallepregunta = new HashSet<Detallepregunta>();
        //}

        public int Id { get; set; }
        public int? FkPndId { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }

        public virtual Ponderacion FkPnd { get; set; }
      //  public virtual ICollection<Detallepregunta> Detallepregunta { get; set; }
    }
}
