using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caixa.Infra.Entities.Response.Transacao
{
    public class ListaTransacoes
    {
        public int Id { get; set; }
        public int ComercianteId { get; set; }
        public int TipoTransacaoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}
