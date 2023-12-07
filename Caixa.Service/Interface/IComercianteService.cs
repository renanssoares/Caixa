using Caixa.Infra.Entities;
using Caixa.Infra.Entities.Request.Comerciante;
using Caixa.Infra.Entities.Response.Comerciante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
