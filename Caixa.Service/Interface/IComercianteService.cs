using Caixa.Infra.Entities;
using Caixa.Infra.Entities.Request.Comerciante;
using Caixa.Infra.Entities.Response.Comerciante;

namespace Caixa.Service.Interface
{
    public interface IComercianteService
    {
        public Task<Comerciante> ObterComerciante(int id);
        public Task<IEnumerable<ListaComerciantes>> ObterListaComerciantes();
        public Task<bool> InserirComerciante(InserirComerciante request);
        public Task<bool> AlterarComerciante(int id,AlterarComerciante request);
    }
}
