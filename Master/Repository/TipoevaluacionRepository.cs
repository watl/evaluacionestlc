using EvalCore.Data;
using EvalCore.Interface;
using EvalCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvalCore.Repository
{
    public  class TipoevaluacionRepository : ITipoevaluacionRepository 
    {
        protected readonly ApplicationDbContext _context;

        public TipoevaluacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tpevaluacion> Get(int id)
        {
            return await _context.Tpevaluacion.FindAsync(id);
        }

        public async Task<IEnumerable<Tpevaluacion>> GetAll()
        {
            return await _context.Tpevaluacion.ToListAsync();
        }
    }
}
