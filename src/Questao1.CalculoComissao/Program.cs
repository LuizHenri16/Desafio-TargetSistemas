using System.Text.Json;


// Importando o arquivo JSON que contém as vendas (dados retirados do documento fornecido no email)
string jsonString = File.ReadAllText("vendas.json");
var vendas = JsonSerializer.Deserialize<DadosVendas>(jsonString);


if (vendas == null || vendas.Vendas == null)
{
    Console.WriteLine("Nenhuma venda encontrada."); // Vamos exibir essa mensagem de erro caso não haja vendas no arquivo JSON
    return;
} 

// Executando os métodos para exibir as vendas e o resumo de vendas por vendedor
vendas.ExibirVendas();
vendas.ExibirResumoVendedores();
