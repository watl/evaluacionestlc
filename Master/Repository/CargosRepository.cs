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
    public class CargosRepository : ICargoRepository
    {
        protected readonly ApplicationDbContext _context;

        public CargosRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Cargos> Get(int id)
        {
            return await _context.Cargos.FindAsync(id);
        }

        public  async Task<List<Cargos>> GetAll()
        {
         var lcr = await _context.Cargos.ToListAsync();
         return lcr;
        }

        public List<Cargos> GetList()
        {
            List<Cargos> lcr = new List<Cargos>();
            lcr =  _context.Cargos.ToList();
            return lcr;
        }
    }
}
