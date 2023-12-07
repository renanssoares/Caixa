using Caixa.Service.Dto;
using Caixa.Service.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public IEnumerable<TipoTransacaoDto> Get()
        {
            var result = _tipoTransacaoService.ObterTransacoes();

            return result;
        }

        // GET api/<TipoTransacaoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TipoTransacaoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TipoTransacaoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TipoTransacaoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
