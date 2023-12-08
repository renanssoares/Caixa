using Caixa.Service.Dto;

namespace Caixa.Service.Interface
{
    public interface ITipoTransacaoService
    {
        public Task<IEnumerable<TipoTransacaoDto>> ObterTransacoes();

    }
}
