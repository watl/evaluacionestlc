using EvalCore.Models;
using EvalCore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvalCore.Interface
{
  public interface IDireccionRepository
    {
        Task<Direcciones> Get(int id);
        Task<IEnumerable<DirecViewDto>> GetAll();
        Task<IEnumerable<DeptoViewDto>> GetAllDepartaments();

        IEnumerable<DeptoViewDto> GetProyectos();
    }
}
