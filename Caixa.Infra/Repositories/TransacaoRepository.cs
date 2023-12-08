using Caixa.Infra.Entities;
using Caixa.Infra.Entities.Request.Transacao;
using Caixa.Infra.Entities.Response.Transacao;
using Caixa.Infra.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Caixa.Infra.Repositories
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly string connectionString;

        public TransacaoRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ListaTransacoes>> ObterListaTransacoes()
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM Transacao";

                var result = await sqlConn.QueryAsync<ListaTransacoes>(query);

                return result;
            }
        }

        public async Task<Transacao> ObterTransacao(int id)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                var query = $@"SELECT * FROM Transacao
                               WHERE Id = @Id";

                var param = new
                {
                    Id = id
                };

                var result = await sqlConn.QueryFirstOrDefaultAsync<Transacao>(query, param);

                return result;
            }
        }
         
        public async Task<IEnumerable<SaldoConsolidado>> ObterSaldoConsolidado(int comercianteId, DateTime dataInicio, DateTime dataFim)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                var query = $@"SELECT
                                     DISTINCT CONVERT(VARCHAR, Data, 103) as Data,
                                     c.Nome,
                                     SUM(CASE WHEN TipoTransacaoId = 1 THEN valor ELSE -valor END) OVER (ORDER BY Data) AS Consolidado
                                 FROM
                                      Transacao t
	                                    JOIN Comerciante c ON t.ComercianteId = c.Id
                                WHERE ComercianteId = @ComercianteId 
                                  AND CONVERT(VARCHAR,Data,103) >= CONVERT(VARCHAR,'{dataInicio.ToShortDateString()}',103)
                                  AND CONVERT(VARCHAR,Data,103) <= CONVERT(VARCHAR,'{dataFim.ToShortDateString()}',103)
                              ORDER BY
                                     Data;";

                var param = new
                {
                    ComercianteId = comercianteId,
                    DataInicial = dataInicio.ToShortDateString(),
                    DataFinal = dataFim.ToShortDateString()
                };

                var result = await sqlConn.QueryAsync<SaldoConsolidado>(query, param);

                return result;
            }
        }

        public async Task<bool> AlterarTransacao(int id, AlterarTransacao request)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                var query = $@"UPDATE Transacao
                               SET ComercianteId = @ComercianteId,
                                   Valor = @Valor,
                                   Descricao = @Descricao
                               WHERE Id = @Id";

                var param = new
                {
                    Id = request.Id,
                    ComercianteId = request.ComercianteId,
                    Valor = request.Valor,
                    Decricao = request.Descricao
                };

                var result = await sqlConn.ExecuteAsync(query, param) > 0;

                return result;
            }
        }

        public async Task<bool> InserirTransacao(InserirTransacao request)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                var query = $@"INSERT INTO Transacao
                                  (ComercianteId,
                                   TipoTransacaoId,
                                   Valor,
                                   Data,
                                   Descricao)
                               VALUES 
                                  (@ComercianteId,
                                   @TipoTransacaoId,
                                   @Valor,
                                   @Data,
                                   @Descricao)";

                var param = new
                {
                    ComercianteId = request.ComercianteId,
                    TipoTransacaoId = request.TipoTransacaoId,
                    Valor = request.Valor,
                    Data = DateTime.Now,
                    Descricao = request.Descricao
                };

                var result = await sqlConn.ExecuteAsync(query, param) > 0;

                return result;
            }
        }

        public async Task<bool> DeletarTransacao(int id)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                var query = $@"DELETE FROM Transacao
                               WHERE Id = @Id";

                var param = new
                {
                    Id = id
                };

                var result = await sqlConn.ExecuteAsync(query, param) > 0;

                return result;
            }
        }
    }
}
