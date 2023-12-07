using Caixa.Infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Infra.Interface
{
    public interface ITipoTransacaoRepository
    {
        public IEnumerable<TipoTransacao> ObterTransacoes();
    }
}
