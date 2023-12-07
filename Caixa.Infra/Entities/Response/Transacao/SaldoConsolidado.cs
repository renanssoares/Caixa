using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Infra.Entities.Response.Transacao
{
    public class SaldoConsolidado
    {
        public string Nome { get; set; }
        public string Consolidado { get; set; }
        public DateTime Data { get; set; }
    }
}
