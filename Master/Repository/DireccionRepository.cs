using EvalCore.Data;
using EvalCore.Interface;
using EvalCore.Models;
using EvalCore.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvalCore.Repository
{
    public  class DireccionRepository : IDireccionRepository 
    {
        protected readonly ApplicationDbContext _context;

        public DireccionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Direcciones> Get(int id)
        {
            return await _context.Direcciones.FindAsync(id);
        }

        public async Task<IEnumerable<DirecViewDto>> GetAll()
        {
            var query = _context.Direcciones
                        .OrderBy(x => x.DirId);
             

            var drc = from o in query
                         select new DirecViewDto()
                         {
                             DirId = o.DirId,
                             DirNombre = o.DirNombre                         
                         };

            return await drc.ToListAsync();
             
        }

        public async Task<IEnumerable<DeptoViewDto>> GetAllDepartaments()
        {
            var query = _context.DepartamentoProyectos
                        .OrderBy(x => x.KeyDepartamentoProyecto);

            var pry = from d in query
                      select new DeptoViewDto()
                      {
                          KeyDproy = d.KeyDepartamentoProyecto,
                          Nombre = d.Nombre
                      };

            return await pry.ToListAsync();
        }

        public IEnumerable<DeptoViewDto> GetProyectos()
        {
            var query = _context.DepartamentoProyectos
                        .OrderBy(x => x.KeyDepartamentoProyecto);

            var pry = from d in query
                      select new DeptoViewDto()
                      {
                          KeyDproy = d.KeyDepartamentoProyecto,
                          Nombre = d.Nombre,
                          Dirid = Convert.ToInt32(d.DirId)
                      };

            return  pry.ToList();
        }


    }
}
