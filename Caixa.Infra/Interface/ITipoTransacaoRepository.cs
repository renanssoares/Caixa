using Caixa.Infra.Entities;

namespace Caixa.Infra.Interface
{
    public interface ITipoTransacaoRepository
    {
        public Task<IEnumerable<TipoTransacao>> ObterTransacoes();
        public Task<TipoTransacao> ObterTipoTransacao(int id);
    }
}
