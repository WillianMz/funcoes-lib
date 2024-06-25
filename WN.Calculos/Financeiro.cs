namespace WN.Calculos
{
    public class Financeiro
    {
        public static double CalcularMargemDelucro(double custo, double venda)
        {
            double margem = ((venda - custo) / custo) * 100;
            return margem;
        }
    }
}
