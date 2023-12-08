using Caixa.Infra.Entities;
using Caixa.Infra.Interface;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Caixa.Infra.Repositories
{
    public class TipoTransacaoRepository : ITipoTransacaoRepository
    {
        private readonly string connectionString;

        public TipoTransacaoRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<TipoTransacao>> ObterTransacoes()
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM TipoTransacao";

                var result = await sqlConn.QueryAsync<TipoTransacao>(query);

                return result;
            }
        }

        public async Task<TipoTransacao> ObterTipoTransacao(int id)
        {
            using (var sqlConn = new SqlConnection(connectionString))
            {
                var query = $@"SELECT * FROM TipoTransacao
                               WHERE Id = @Id";

                var param = new
                {
                    Id = id
                };

                var result = await sqlConn.QueryFirstOrDefaultAsync<TipoTransacao>(query, param);

                return result;
            }
        }

    }
}
