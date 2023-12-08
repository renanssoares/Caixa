namespace Caixa.Infra.Entities.Request.Transacao
{
    public class AlterarTransacao
    {
        public int Id { get; set; }
        public int ComercianteId { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }
}
