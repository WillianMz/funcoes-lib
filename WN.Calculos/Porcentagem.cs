namespace WN.Calculos
{
    public class Porcentagem
    {
        public static decimal CalculcarPorcDesconto(decimal valorTotal, decimal valorDesconto)
        {
            //formula
            // % = valor desconto x 100 / valor total (preco)
            decimal porcentagem = (valorDesconto * 100) / valorTotal;
            return porcentagem;
        }

        public static decimal CalcularPorcAcrescimo(decimal valorAnterior, decimal novoValor)
        {
            //formula
            // descobrir o valor do acrescimo
            // %acrescimo = valor do acrescimo x 100 / valorAnterior
            decimal valorAcrescimo = novoValor - valorAnterior;
            decimal acrescimo = (valorAcrescimo * 100) / valorAnterior;
            return acrescimo;
        }
    }
}
