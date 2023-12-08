namespace Caixa.Api.Validation
{
    public static class Validation
    {
        public static void StringNuloOuVazio(string valor, string nome)
        {
            if (string.IsNullOrEmpty(valor))
                throw new ArgumentNullException(nome, "O campo não pode ser nulo ou vazio.");
        }

        public static void DecimalZeroOuMenor(decimal valor, string nome)
        {
            if (valor <= 0)
                throw new ArgumentNullException(nome, "O campo deve possuir um valor positivo.");
        }


        public static void IntZeroOuMenor(int valor, string nome)
        {
            if (valor <= 0)
                throw new ArgumentNullException(nome, "O campo deve possuir um valor positivo.");
        }

        public static void CnpjInvalido(string valor, string nome)
        {
            if (!ValidaDigitoCNPJ.ValidaCNPJ(valor))
                throw new ArgumentNullException(nome, "O CNPJ deve ser válido.");
        }
    }
}
