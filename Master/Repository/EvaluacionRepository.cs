using Dapper;
using EvalCore.Data;
using EvalCore.Interface;
using EvalCore.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EvalCore.Repository
{
    public class EvaluacionRepository : BaseRepository, IEvaluacionInterface
    {
        protected readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;

        public EvaluacionRepository(ApplicationDbContext context, IConfiguration configuration): base(configuration)
        {
            _context = context;
            this.configuration = configuration;
        }



        public void SaveDetallePregunta(List<Detallepregunta> prg)
        {
            _context.Detallepregunta.AddRange(prg);
            _context.SaveChanges();
        }

        public void InsertarEvaluacion(Evaluacion ev)
        {
            _context.Evaluacion.Add(ev);
        }

        public void InsertarEvaluacionDetalle(Evaluaciodetalle dteva)
        {
            _context.Evaluaciodetalle.Add(dteva);
        }

        public void ObtenerUltimaDetallePregunta(int evqt)
        {
            throw new NotImplementedException();
        }

        public void ObtenerUltimaEvaluacion()
        {
            throw new NotImplementedException();
        }

        public void ObtenerUltimaEvaluacionDetalle(int evdt)
        {
            throw new NotImplementedException();
        }

       
    }
}
