using System.Globalization;

var cultura = new CultureInfo("pt-BR");

Console.Write("Informe o valor original: R$ ");
decimal valorOriginal = decimal.Parse(Console.ReadLine()!, cultura);

Console.Write("Informe a data de vencimento (dd/MM/yyyy): ");
DateTime vencimento = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", cultura);

DateTime hoje = DateTime.Today;
var cobranca = new Cobranca(valorOriginal, vencimento);

Console.WriteLine("\n--- RESULTADO ---");
Console.WriteLine($"Data de Vencimento: {vencimento:dd/MM/yyyy}");
Console.WriteLine($"Data Atual:         {hoje:dd/MM/yyyy}");
Console.WriteLine($"Dias em Atraso:     {cobranca.DiasAtraso} dia(s)");
Console.WriteLine($"Valor dos Juros:    {cobranca.ValorJuros.ToString("C2", cultura)}");
Console.WriteLine($"Valor Total:        {cobranca.ValorTotal.ToString("C2", cultura)}");