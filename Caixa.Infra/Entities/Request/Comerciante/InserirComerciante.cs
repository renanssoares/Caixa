using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Infra.Entities.Request.Comerciante
{
    public class InserirComerciante
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public bool Ativo { get; set; }

    }
}
