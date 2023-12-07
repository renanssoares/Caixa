using Caixa.Infra.Entities;
using Caixa.Infra.Entities.Request.Transacao;
using Caixa.Infra.Entities.Response.Transacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Service.Interface
{
    public interface ITransacaoService
    {
        public Task<Transacao> ObterTransacao(int id);
        public Task<IEnumerable<ListaTransacoes>> ObterListaTransacoes();
        public Task<IEnumerable<SaldoConsolidado>> ObterSaldoConsolidado(int comercianteId, DateTime dataInicio, DateTime dataFim);
        public Task<bool> InserirTransacao(InserirTransacao request);
        public Task<bool> AlterarTransacao(int id,AlterarTransacao request);
        public Task<bool> DeletarTransacao(int id);
    }
}
