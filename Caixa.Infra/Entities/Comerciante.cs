﻿namespace Caixa.Infra.Entities
{
    public  class Comerciante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public bool Ativo { get; set; }
    }
}
