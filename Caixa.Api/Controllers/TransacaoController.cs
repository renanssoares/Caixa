using Caixa.Infra.Entities;
using Caixa.Infra.Entities.Request.Transacao;
using Caixa.Infra.Entities.Response.Transacao;
using Caixa.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Caixa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _service;

        public TransacaoController(ITransacaoService service)
        {
            _service = service;
        }

        // GET: api/<TransacaoController>
        [HttpGet]
        public async Task<IEnumerable<ListaTransacoes>> Get()
        {
            var result = await _service.ObterListaTransacoes();
            return result;
        }

        // GET api/<TransacaoController>/5
        [HttpGet("{id}")]
        public async Task<Transacao> Get(int id)
        {
            var result = await _service.ObterTransacao(id);
            return result;
        }

        // GET: api/<TransacaoController>
        [HttpGet, Route("saldo-consolidado")]
        public async Task<IEnumerable<SaldoConsolidado>> GetSaldoConsolidado(int comercianteId, DateTime dataInicio, DateTime datafim)
        {
            var result = await _service.ObterSaldoConsolidado(comercianteId, dataInicio, datafim);
            return result;
        }

        // POST api/<TransacaoController>
        [HttpPost]
        public async Task<bool> Post([FromBody] InserirTransacao request)
        {
            Validation.Validation.DecimalZeroOuMenor(request.Valor, nameof(request.Valor));
            Validation.Validation.IntZeroOuMenor(request.ComercianteId, nameof(request.Valor));
            Validation.Validation.IntZeroOuMenor(request.TipoTransacaoId, nameof(request.Valor));

            var result = await _service.InserirTransacao(request);
            return result;
        }

        // PUT api/<TransacaoController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] AlterarTransacao request)
        {
            Validation.Validation.DecimalZeroOuMenor(request.Valor, nameof(request.Valor));
            Validation.Validation.IntZeroOuMenor(request.Id, nameof(request.Valor));

            var result = await _service.AlterarTransacao(id, request);
            return result;
        }

        // DELETE api/<TransacaoController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await _service.DeletarTransacao(id);
            return result;
        }

    }
}
