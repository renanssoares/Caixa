using Caixa.Infra.Entities.Request.Transacao;
using Caixa.Infra.Entities.Response.Transacao;
using Caixa.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caixa.Infra.Entities.Response.Comerciante;
using Caixa.Infra.Entities.Request.Comerciante;

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
