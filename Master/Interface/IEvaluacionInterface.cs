using EvalCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvalCore.Interface
{
    public interface IEvaluacionInterface
    {
        void InsertarEvaluacion(Evaluacion ev);
        void ObtenerUltimaEvaluacion();
        void ObtenerUltimaEvaluacionDetalle(int evdt);
        void ObtenerUltimaDetallePregunta(int evqt);
        void InsertarEvaluacionDetalle(Evaluaciodetalle dteva);
        void SaveDetallePregunta(List<Detallepregunta> prg);

    }
}
