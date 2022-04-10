using EvalCore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvalCore.Interface
{
    public interface IAdminrhInterface
    {

        Task<List<FuncdeptoViewDto>> Obtenerfuncionariosxdepartamento(int dirid, int idproy);

    }
}
