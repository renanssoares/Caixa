using Caixa.Infra.Entities;
using Caixa.Infra.Entities.Request.Comerciante;
using Caixa.Infra.Entities.Response.Comerciante;
using Caixa.Infra.Interface;
using Caixa.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Service.Services
{
    public class ComercianteService : IComercianteService
    {
        private readonly IComercianteRepository _repository;

        public ComercianteService(IComercianteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Comerciante> ObterComerciante(int id)
        {
            var result = await _repository.ObterComerciante(id);
            return result;
        }

        public async Task<IEnumerable<ListaComerciantes>> ObterListaComerciantes()
        {
            var result = await _repository.ObterListaComerciantes();
            return result;
        }

        public async Task<bool> InserirComerciante(InserirComerciante request)
        {
            var result = await _repository.InserirComerciante(request);
            return result;
        }

        public async Task<bool> AlterarComerciante(int id, AlterarComerciante request)
        {
            var result = await _repository.AlterarComerciante(id, request);
            return result;
        }
    }
}
