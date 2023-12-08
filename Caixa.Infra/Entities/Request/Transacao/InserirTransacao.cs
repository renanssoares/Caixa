namespace Caixa.Infra.Entities.Request.Transacao
{
    public class InserirTransacao
    {
        public int ComercianteId { get; set; }
        public int TipoTransacaoId { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}
