using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EvalCore.Models
{
    public partial class Funcionarios
    {
        //public Funcionarios()
        //{
        //    Detallepregunta = new HashSet<Detallepregunta>();
        //    Evaluaciodetalle = new HashSet<Evaluaciodetalle>();
        //}

        public decimal FunId { get; set; }
        public string FunNombre { get; set; }
        public string FunApellidos { get; set; }
        public decimal? CarId { get; set; }
        public decimal? DirId { get; set; }
        public DateTime? FunFnac { get; set; }
        public DateTime? FunIngreso { get; set; }
        public string FunDireccion { get; set; }
        public DateTime? FunFechaIngreso { get; set; }
        public bool? FunActivo { get; set; }
        public string FunCedula { get; set; }
        public decimal SexoId { get; set; }
        public decimal? JefeId { get; set; }
        public decimal? FunCodigo { get; set; }
        public int? DepId { get; set; }
        public int? KeyDepartamentoProy { get; set; }
        public int? KeySeccion { get; set; }
        public int? KeyUbicacion { get; set; }

        public virtual Cargos Car { get; set; }
        public virtual DepartamentoProyectos Dep { get; set; }
        public virtual Direcciones Dir { get; set; }
        //public virtual ICollection<Detallepregunta> Detallepregunta { get; set; }
        //public virtual ICollection<Evaluaciodetalle> Evaluaciodetalle { get; set; }
    }
}
