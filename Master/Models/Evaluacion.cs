using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EvalCore.Models
{
    public partial class Evaluacion
    {
        public int KeyEval { get; set; }
        public DateTime? Periodoinicial { get; set; }
        public DateTime? Periodofinal { get; set; }
        public DateTime? Fecha { get; set; }
        public string Usuario { get; set; }
        public bool? Estado { get; set; }
    }
}
