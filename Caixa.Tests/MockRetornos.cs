using Caixa.Infra.Entities;

namespace Caixa.Tests
{
    public static class MockRetornos
    {

         
        public static Transacao RetornaTransacao()
        {
            var transacao = new Transacao();
            transacao.Id = 1;
            transacao.ComercianteId = 1;
            transacao.TipoTransacaoId = 1;
            transacao.Valor= 10;
            transacao.Data = DateTime.Now;
            transacao.Descricao = "";

            return transacao;
        }

    }

}
