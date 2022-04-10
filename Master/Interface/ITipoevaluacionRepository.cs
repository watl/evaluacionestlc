using EvalCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvalCore.Interface
{
  public interface ITipoevaluacionRepository
    {
        Task<Tpevaluacion> Get(int id);
        Task<IEnumerable<Tpevaluacion>> GetAll();

    }
}
