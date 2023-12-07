using Caixa.Infra.Entities;
using Caixa.Infra.Entities.Request.Transacao;
using Caixa.Infra.Entities.Response.Transacao;
using Caixa.Infra.Interface;
using Caixa.Service.Dto;
using Caixa.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Service.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _repository;

        public TransacaoService(ITransacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Transacao> ObterTransacao(int id)
        {
            var result = await _repository.ObterTransacao(id);
            return result;
        }

        public async Task<IEnumerable<ListaTransacoes>> ObterListaTransacoes()
        {
            var result = await _repository.ObterListaTransacoes();
            return result;
        }

        public async Task<IEnumerable<SaldoConsolidado>> ObterSaldoConsolidado(int comercianteId, DateTime dataInicio, DateTime dataFim)
        {
            var result = await _repository.ObterSaldoConsolidado(comercianteId, dataInicio, dataFim);
            return result;
        }

        public async Task<bool> InserirTransacao(InserirTransacao request)
        {
            var result = await _repository.InserirTransacao(request);
            return result;
        }

        public async Task<bool> AlterarTransacao(int id, AlterarTransacao request)
        {
            var result = await _repository.AlterarTransacao(id, request);
            return result;
        }

        public async Task<bool> DeletarTransacao(int id)
        {
            var result = await _repository.DeletarTransacao(id);
            return result;
        }
    }
}
