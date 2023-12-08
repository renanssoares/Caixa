using Caixa.Infra.Entities;
using Caixa.Infra.Entities.Request.Transacao;
using Caixa.Infra.Entities.Response.Transacao;
using Caixa.Infra.Interface;
using Caixa.Service.Interface;

namespace Caixa.Service.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _repository;
        private readonly ITipoTransacaoRepository _tiporepository;
        private readonly IComercianteRepository _comercianteRepository;

        public TransacaoService(ITransacaoRepository repository,
                                ITipoTransacaoRepository tiporepository,
                                IComercianteRepository comercianteRepository)
        {
            _repository = repository;
            _tiporepository = tiporepository;
            _comercianteRepository = comercianteRepository;
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
            await ValidaComerciante(request.ComercianteId);
            await ValidaTipoTransacao(request.TipoTransacaoId);

            var result = await _repository.InserirTransacao(request);
            return result;
        }
 
        public async Task<bool> AlterarTransacao(int id, AlterarTransacao request)
        {
            await ValidaComerciante(request.ComercianteId); 

            var result = await _repository.AlterarTransacao(id, request);
            return result;
        }

        public async Task<bool> DeletarTransacao(int id)
        {
            var result = await _repository.DeletarTransacao(id);
            return result;
        }

        private async Task ValidaTipoTransacao(int id)
        {
            var tipo = await _tiporepository.ObterTipoTransacao(id);
            if (tipo == null)
                throw new ArgumentNullException(nameof(tipo), "Tipo transação não encontrado.");
        }

        private async Task ValidaComerciante(int id)
        {
            var comerciante = await _comercianteRepository.ObterComerciante(id);
            if (comerciante == null)
                throw new ArgumentNullException(nameof(comerciante), "Comerciante não encontrado.");
        }
    }
}
