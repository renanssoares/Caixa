using Caixa.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Caixa.Infra.Entities.Request.Transacao;
using Caixa.Infra.Entities.Response.Transacao;
using Caixa.Infra.Entities.Response.Comerciante;
using Caixa.Infra.Entities.Request.Comerciante;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using Caixa.Infra.Interface;

namespace Caixa.Infra.Repositories
{
    public class ComercianteRepository : IComercianteRepository
    {
        private readonly string connectionString;

        public ComercianteRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ListaComerciantes>> ObterListaComerciantes()
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM Comerciante";

                var result = await sqlConn.QueryAsync<ListaComerciantes>(query);

                return result;
            }
        }

        public async Task<Comerciante> ObterComerciante(int id)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                var query = $@"SELECT * FROM Comerciante
                               WHERE Id = @Id";

                var param = new
                {
                    Id = id
                };

                var result = await sqlConn.QueryFirstOrDefaultAsync<Comerciante>(query, param);

                return result;
            }
        }
        public async Task<bool> AlterarComerciante(int id, AlterarComerciante request)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                var query = $@"UPDATE Comerciante
                               SET Nome = @Nome,
                                   Cnpj = @Cnpj,
                                   Ativo = @Ativo
                               WHERE Id = @Id";

                var param = new
                {
                    Id = id,
                    Nome = request.Nome,
                    Ativo = request.Ativo,
                    Cnpj = request.Cnpj
                };

                var result = await sqlConn.ExecuteAsync(query, param) > 0;

                return result;
            }
        }

        public async Task<bool> InserirComerciante(InserirComerciante request)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                var query = $@"INSERT INTO Comerciante
                                  (Nome,
                                   Cnpj,
                                   Ativo)
                               VALUES 
                                  (@Nome,
                                   @Cnpj,
                                   @Ativo)";

                var param = new
                {
                    Nome = request.Nome,
                    Cnpj = request.Cnpj,
                    Ativo = true
                };

                var result = await sqlConn.ExecuteAsync(query, param) > 0;

                return result;
            }
        }

        //public async Task<bool> DeletarTransacao(int id)
        //{
        //    using (var sqlConn = new SqlConnection(connectionString))
        //    {
        //        var query = $@"UPDATE Comerciante
        //                       SET Ativo = @Ativo
        //                       WHERE Id = @Id";

        //        var param = new
        //        {
        //            Id = Id,
        //            Ativo = request.Nome                    
        //        };

        //        var result = await sqlConn.ExecuteAsync(query, param) > 0;

        //        return result;
        //    }
        //}

    }
}
