using WN.Funcoes.Classes;

namespace WN.Funcoes
{
    public class Parcelador
    {
        private const int MAX_PARCELAS = 12;

        /// <summary>
        /// Retorna o numero logo antes da vírgula (ou ponto)
        /// 123.45 = 3 | 1002.01 = 2
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private static int GetDigitoUnitario(decimal valor)
        {
            if (valor < 1)
                return 0;

            string valorConvertido = (Math.Truncate(valor)).ToString();
            return Convert.ToInt16(valorConvertido.Substring(valorConvertido.Length -1 , 1));
        }

        public static decimal[] CalcularParcelas(decimal valorTotal, int numeroParcelas)
        {
            try
            {
                //cria o retorno
                decimal[] parcelas = new decimal[MAX_PARCELAS];

                //verifica a quantidade maxima de parcelas permitidas
                if (numeroParcelas > MAX_PARCELAS)
                    throw new Exception($"O númeo máximo de parcelas é {MAX_PARCELAS}");

                //calcula o valor da parcela e centavos
                decimal valorParcela = valorTotal / numeroParcelas;
                decimal valorCentavos = (valorParcela - Math.Truncate(valorParcela)) * numeroParcelas;
                valorParcela = Math.Truncate(valorParcela);

                // se a parcela for maior que 30 reais faz o arredondamento na casa decimal
                // assim, se o dígito antes da vírgula for 1 ou 2 ele arrendonda para baixo  (ex: 11,00 e 12,00  puxa pra 10,00)
                // se o dígito for 6 ou 7 ele arredonda para 5.  (ex: 16,00 ou 17,00 puxa para 15,00)
                // se o dígito for 3 ou 4 arredonda para 5. (ex: 13,00 ou 14,00 puxa para 15,00)
                // se o dígito for 8 ou 9 arredonda para 10. (ex: 18,00 ou 19,00 puxa para 20,00)
                if (valorParcela > 30)
                {
                    int digito = GetDigitoUnitario(valorParcela);
                    switch(digito)
                    {
                        case 1:
                        case 2: valorParcela -= digito; break;
                        case 6:
                        case 7: valorParcela -= (digito - 5); break;
                        case 3:
                        case 4: valorParcela += (5 - digito); break;
                        case 8:
                        case 9: valorParcela += (10 - digito); break;
                    }
                }

                // a diferença será adicional na última parcela (quer seja positiva ou negativa)
                decimal diferenca = valorTotal - (valorParcela * numeroParcelas);
                
                // seta o valor das parcelas
                for ( int i = 0; i < numeroParcelas; i++ )
                {
                    parcelas[i] = valorParcela;
                }
                
                // coloca a diferença na última
                parcelas[numeroParcelas - 1] = parcelas[numeroParcelas - 1] + diferenca;
                // parcelas[nParcelas-1] + vCentavos;

                return parcelas;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao calcular parcelas. {ex.Message}");
            }
        }

        public static List<Parcela> GerarParcelas(decimal valorTotal, int numeroParcelas)
        {
            //decimal valorTotal = 200.00M;
            //int numeroParcelas = 3;
            DateTime dataPrimeiroVencimento = DateTime.Now;
            List<Parcela> parcelas = [];

            decimal valorParcela = Math.Round(valorTotal / numeroParcelas, 2);
            decimal valorDiferenca = valorTotal - valorParcela * numeroParcelas;

            for (int i = 0; i < numeroParcelas; i++)
            {

                //Calculo dos valores;
                string parcela = (i + 1).ToString().PadLeft(2, '0');
                decimal valor = !(i + 1 == numeroParcelas) ? valorParcela : (valorParcela + valorDiferenca);
                var dataVencimento = dataPrimeiroVencimento.AddMonths(i);
                Parcela parcela1 = new(i, Convert.ToDecimal(valor), dataVencimento);
                parcelas.Add(parcela1);

                //Exemplo do resultado
                //Console.WriteLine(parcela + " | " + valor + " | " + dataVencimento);
            }

            return parcelas;
        }
    }
}
