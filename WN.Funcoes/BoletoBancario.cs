namespace WN.Funcoes
{
    public class BoletoBancario
    {
        //codigo de barras: tamanho = 44
        //linha digital: tamanho = 47

        //linha digitavel
        public static DateOnly ExtrairDataDeVencimento(string cnab)
        {
            string database = "07/10/1997";
            DateOnly dataVencimento;
            int posicao;

            if (cnab.Length == 44)
            {
                posicao = int.Parse(cnab.Substring(05, 4));//posicao 06-09
                dataVencimento = DateOnly.Parse(database);
                dataVencimento = dataVencimento.AddDays(posicao);
                return dataVencimento;
            }
            else if (cnab.Length == 47)
            {
                posicao = int.Parse(cnab.Substring(33, 4));//posicao 34-37
                dataVencimento = DateOnly.Parse(database);
                dataVencimento = dataVencimento.AddDays(posicao);
                return dataVencimento;
            }
            else
                throw new Exception($"Tamanho do CNAB é inválido!");
        }

        public static int ExtrarCodigoBanco(string cnab)
        {
            int banco = int.Parse(cnab.Substring(0, 3));
            return banco;
        }

        public static double ExtrairValor(string cnab)
        {
            var posicao = cnab.Substring(37, 10);
            var valor = double.Parse(posicao) / 100;
            return valor;
        }
    }
}
