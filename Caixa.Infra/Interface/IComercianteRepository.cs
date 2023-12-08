using Caixa.Infra.Entities;
using Caixa.Infra.Entities.Request.Comerciante;
using Caixa.Infra.Entities.Response.Comerciante;

namespace Caixa.Infra.Interface
{
    public interface IComercianteRepository
    {
        public Task<IEnumerable<ListaComerciantes>> ObterListaComerciantes();
        public Task<Comerciante> ObterComerciante(int id);
        public Task<bool> InserirComerciante(InserirComerciante request);
        public Task<bool> AlterarComerciante(int id, AlterarComerciante request);
    }
}
