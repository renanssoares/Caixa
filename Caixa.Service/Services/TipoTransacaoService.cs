using Caixa.Infra.Interface;
using Caixa.Service.Dto;
using Caixa.Service.Interface;

namespace Caixa.Service.Services
{
    public class TipoTransacaoService : ITipoTransacaoService
    {
        private readonly ITipoTransacaoRepository _repository;

        public TipoTransacaoService(ITipoTransacaoRepository repository)
        {
            _repository = repository;
        }
          
        public async Task<IEnumerable<TipoTransacaoDto>> ObterTransacoes()
        {
            var retorno = await _repository.ObterTransacoes();

            List<TipoTransacaoDto> ret = new List<TipoTransacaoDto>();

            foreach (var item in retorno)
            {
                var dto = new TipoTransacaoDto()
                {
                    Id = item.Id,
                    Nome = item.Nome
                };

                ret.Add(dto);
            }

            return ret;
        }
          
    }
}
