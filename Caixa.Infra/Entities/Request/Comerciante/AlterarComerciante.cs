namespace Caixa.Infra.Entities.Request.Comerciante
{
    public class AlterarComerciante
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public bool Ativo { get;set; }
    }
}
