using Dapper;
using EvalCore.Data;
using EvalCore.Interface;
using EvalCore.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EvalCore.Repository
{
    public class AdminrhRepository : BaseRepository, IAdminrhInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration configuration;
        public AdminrhRepository(ApplicationDbContext context, IConfiguration configuration): base(configuration)
        {
            _context = context;
            this.configuration = configuration;
        }

        public async Task<List<FuncdeptoViewDto>> Obtenerfuncionariosxdepartamento(int dirid, int idproy)
        {
            string procedure = "sp_Obtenerfuncionariosxdepartamento";
            using (var cnx = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                cnx.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@DirID", dirid, DbType.Int32, ParameterDirection.Input);
                parameter.Add("@ProyID", idproy, DbType.Int32, ParameterDirection.Input);

                var splist = (await cnx.QueryAsync<FuncdeptoViewDto>(procedure,parameter,
                commandType: CommandType.StoredProcedure));
                cnx.Close();
                return splist.ToList();
            }
        }




    }
}
