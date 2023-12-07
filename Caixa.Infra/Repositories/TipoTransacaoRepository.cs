using Caixa.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Caixa.Infra.Interface;
using Microsoft.Extensions.Configuration;

namespace Caixa.Infra.Repositories
{
    public class TipoTransacaoRepository : ITipoTransacaoRepository
    {
        private readonly string connectionString;

        public TipoTransacaoRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<TipoTransacao> ObterTransacoes()
        {
            
            using (var sqlConn = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM TipoTransacao";

                var result = sqlConn.Query<TipoTransacao>(query);

                return result;

            }


        }


    }
}
