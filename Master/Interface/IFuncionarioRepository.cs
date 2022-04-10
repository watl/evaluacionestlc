using EvalCore.Models;
using EvalCore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvalCore.Interface
{
    public interface IFuncionarioRepository
    {
        Task<Funcionarios> Get(int id);
        Task<Funcionarios> TT(int id);
        Task<IEnumerable<FuncViewDto>> GetAll();
        Task<List<PreguntasViewDto>> GetAllQuestions();
        Task<IEnumerable<FuncViewDto>> GetAlldto();
    }
}
