using Caixa.Service.Dto;
using Caixa.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Caixa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTransacaoController : ControllerBase
    {
        private readonly ITipoTransacaoService _tipoTransacaoService;
        public TipoTransacaoController(ITipoTransacaoService tipoTransacaoService)
        {
            _tipoTransacaoService = tipoTransacaoService;
        }

        // GET: api/<TipoTransacaoController>
        [HttpGet]
        public async Task<IEnumerable<TipoTransacaoDto>> Get()
        {
            var result = await _tipoTransacaoService.ObterTransacoes();

            return result;
        }
    }
}
