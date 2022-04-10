using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EvalCore.Models
{
    public partial class Evaluaciodetalle
    {
        public int KeyEvdt { get; set; }
        public int? Fkeva { get; set; }
        public decimal? FunId { get; set; }
        public int? Fktipoeva { get; set; }
        public int? Blq1 { get; set; }
        public int? Blq2 { get; set; }
        public int? Blq3 { get; set; }
        public int? Blq4 { get; set; }
        public int? Bltotal { get; set; }
        public int? CarId { get; set; }
        public int? DirId { get; set; }
        public string Pntescala { get; set; }
        public string Rtfort { get; set; }
        public string Rtdeb { get; set; }
        public string Rtcomp { get; set; }
        public string Rtcapc { get; set; }
        public decimal? Fkfunceval { get; set; }
    }
}
