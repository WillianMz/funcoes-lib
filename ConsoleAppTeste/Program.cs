// See https://aka.ms/new-console-template for more information
using WN.Calculos;
using WN.Funcoes;
using WN.Funcoes.Classes;

Console.WriteLine("Hello, World!");

// essa rotina é chama 1x para cada teste
//static void Mostra(decimal valor, int nParcelas)
//{
//    // vamos calcular as parcelas
//    decimal[] parcelas = Parcelador.CalcularParcelas(valor, nParcelas);
//    decimal total = 0;

//    // mostra o total no output
//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine(string.Format("Valor Total: {0:C}", valor));
//    Console.ForegroundColor = ConsoleColor.White;

//    // soma as parcelas e exibe - vamos ver se a soma bate com o argumento da função
//    for (int i = 0; i < nParcelas; i++)
//    {
//        Console.Write(string.Format("Parcela {0}/{2}   {1:C}\n", i + 1, parcelas[i], nParcelas));
//        total += parcelas[i];
//    }
//    Console.WriteLine("------------------------------");

//    // a soma não bate? --- ERRO!
//    if (valor != total)
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.WriteLine("  ERROR   ERROR   ERROR");
//        Console.ReadLine();
//    }
//}

//Mostra(Convert.ToDecimal(200), 3);

//var margem = Financeiro.CalcularMargemDelucro(9.90, 19.90);
//Console.WriteLine($"Margem de Lucro: {margem}");

var data = BoletoBancario.ExtrairDataDeVencimento("75691307060103197750560587010160795600000009990");
Console.WriteLine($"Data: {data}");

var data1 = BoletoBancario.ExtrairDataDeVencimento("75699956000000099901307001031977506058550001");
Console.WriteLine($"Data: {data1}");

Console.WriteLine($"Banco: {BoletoBancario.ExtrarCodigoBanco("75691307060103197750560587010160795600000009990")}");

var valor = BoletoBancario.ExtrairValor("10496229948000010004200031693484795610000021528").ToString("N2");
Console.WriteLine($"Valor R$ {valor}");

//var parcelas = Parcelador.GerarParcelas((decimal)569.40, 3);
//foreach (var p in parcelas)
//{
//    Console.WriteLine($"{p.Numero} | {p.Valor} | {p.DataVencimento}");
//}


// usando para pegar um double randomico entre 2 valores
static decimal NextDouble(Random rng, double min, double max)
{
    return (decimal)(min + (rng.NextDouble() * (max - min)));
}


const int QTD_TESTES = 3; // 1-10000
const double VL_MINIMO = 10; // 1-9999
const double VL_MAXIMO = 1500; // 1-9999
const int MAX_PARCELAS = 11;  // 1-11  (tem um +2 ali em baixo, então na prática será 2-12)




// vamos testar 
Random random = new();
List<Parcela> parcelas = [];

//for (int i = 0; i < QTD_TESTES; i++)
//{
//    decimal valor = NextDouble(random, VL_MINIMO, VL_MAXIMO);
//    //Mostra(valor, random.Next(MAX_PARCELAS) + 2);
//    Console.WriteLine($"Valor: R$ {valor}");
//    Console.WriteLine("Pressione qualquer tecla para continuar...");
//    Console.ReadLine();
//    parcelas = Parcelador.GerarParcelas(valor, random.Next(MAX_PARCELAS) + 2);
//}

//var valor = NextDouble(random, VL_MINIMO, VL_MAXIMO);
//valor = Math.Round(valor);
//Console.WriteLine($"Valor: R$ {valor}");
//Console.WriteLine("Pressione qualquer tecla para continuar...");
//Console.ReadLine();
//parcelas = Parcelador.GerarParcelas(valor, 12);

//for (int i = 0; i < QTD_TESTES; i++)
//{
//    var valor = NextDouble(random, VL_MINIMO, VL_MAXIMO);
//    valor = Math.Round(valor, 2);
//    Console.WriteLine("");
//    Console.WriteLine($"Valor: R$ {valor}");
//    parcelas = Parcelador.GerarParcelas(valor, 4);
    
//    foreach (var p in parcelas)
//    {
//        Console.WriteLine($"{p.Numero+1} | R$ {p.Valor} | {p.DataVencimento.ToShortDateString()}");
//    }
    
//    Console.WriteLine($"------------------------");
//}

//foreach (var p in parcelas)
//{
//    Console.WriteLine($"{p.Numero} | {p.Valor} | {p.DataVencimento}");
//}

Console.ReadLine();