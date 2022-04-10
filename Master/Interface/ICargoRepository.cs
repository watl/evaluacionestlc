using EvalCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvalCore.Interface
{
    public interface ICargoRepository
    {
  
        Task<Cargos> Get(int id);
        Task<List<Cargos>> GetAll();
        List<Cargos> GetList();
    }
}
