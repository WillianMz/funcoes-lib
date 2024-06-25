namespace WN.Funcoes.Classes
{
    public class Parcela
    {
        public Parcela(int numero, decimal valor, DateTime dataVencimento)
        {
            Numero = numero;
            Valor = valor;
            DataVencimento = dataVencimento;
        }

        public int Numero { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
