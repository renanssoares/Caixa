using Caixa.Infra.Entities;
using Caixa.Infra.Entities.Request;
using Caixa.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Service.Interface
{
    public  interface ITipoTransacaoService
    {
        public IEnumerable<TipoTransacaoDto> ObterTransacoes();

    }
}
