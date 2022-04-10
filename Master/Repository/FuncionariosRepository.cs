using Dapper;
using EvalCore.Data;
using EvalCore.Interface;
using EvalCore.Models;
using EvalCore.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EvalCore.Repository
{
    public class FuncionariosRepository : BaseRepository, IFuncionarioRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;



        public FuncionariosRepository(ApplicationDbContext context, IConfiguration configuration): base(configuration)
        {
            _context = context;
            this.configuration = configuration;
        }
        public async Task<Funcionarios> Get(int id)
        {
            var  Funcr = await _context.Funcionarios.FindAsync(id);
            if(Funcr == null)
            {
                throw new Exception("No se encontro registros");
            }
            return Funcr;
        }

        public async Task<IEnumerable<FuncViewDto>> GetAll()
        {
            string sql = "SELECT f.FUN_ID as Keyfun,FNamefull = rtrim(f.FUN_Nombre)  +' '+ rtrim(f.FUN_Apellidos) " +
                 "FROM dbo.Funcionarios f where f.FUN_Activo = 1";         
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var dt = (await connection.QueryAsync<FuncViewDto>(sql)).ToList();
                connection.Close();
                return dt;               
            }                   
        }
        public async Task<List<PreguntasViewDto>> GetAllQuestions()
        {
           string procedure = "sp_ListadoPreguntas";
            using (var cnx = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                cnx.Open();
                var splist = (await cnx.QueryAsync<PreguntasViewDto>(procedure,
                commandType: CommandType.StoredProcedure));
                cnx.Close();
                return splist.ToList();
            }
        }

        public async Task<IEnumerable<FuncViewDto>> GetAlldto()
        {
       

            var query = _context.Funcionarios.Where(x => x.FunActivo == true);

            var listfc = from o in query
                         select new FuncViewDto()
                         {
                             Keyfun = o.FunId,
                             FNamefull = o.FunNombre.Trim() + " " + o.FunApellidos.Trim(),
                             FCingreso = o.FunFechaIngreso
                         };

            return await listfc.ToListAsync();


        }

        public Task<Funcionarios> TT(int id)
        {
            throw new NotImplementedException();
        }
    }
}
