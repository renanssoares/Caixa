using Caixa.Infra.Entities;
using Caixa.Infra.Entities.Request.Comerciante;
using Caixa.Infra.Entities.Response.Comerciante;
using Caixa.Infra.Entities.Response.Transacao;
using Caixa.Service.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Caixa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercianteController : ControllerBase
    {
        private readonly IComercianteService _service;

        public ComercianteController(IComercianteService service)
        {
            _service = service;
        }

        // GET: api/<ComercianteController>
        [HttpGet]
        public async Task<IEnumerable<ListaComerciantes>> Get()
        {
            var result = await _service.ObterListaComerciantes();
            return result;
        }

        // GET api/<ComercianteController>/5
        [HttpGet("{id}")]
        public async Task<Comerciante> Get(int id)
        {
            var result = await _service.ObterComerciante(id);
            return result;
        }

        // POST api/<ComercianteController>
        [HttpPost]
        public async Task<bool> Post([FromBody] InserirComerciante request)
        {
            var result = await _service.InserirComerciante(request);
            return result;
        }

        // PUT api/<ComercianteController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put(int id, [FromBody] AlterarComerciante request)
        {
            var result = await _service.AlterarComerciante(id, request);
            return result;
        }
    }
}
