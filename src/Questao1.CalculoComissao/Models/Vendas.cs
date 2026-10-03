using System.Globalization;
using System.Text.Json.Serialization;

public class DadosVendas
{

    private static readonly CultureInfo CulturaBR = new("pt-BR"); // Definindo a cultura brasileira para formatação de moeda

    [JsonPropertyName("vendas")]
    public List<Venda> Vendas { get; set; } = new();

    public void ExibirVendas()
    {
        Console.WriteLine("========================================================================");
        Console.WriteLine("                    VENDAS E COMISSÕES POR VENDEDOR                     ");
        Console.WriteLine("========================================================================");
        
        foreach (var venda in Vendas)
        {
            decimal comissao = venda.CalcularComissao();
            string comissaoFormatada = comissao.ToString("C2", CulturaBR); // Formata a comissão como moeda brasileira (R$) para facilitar a leitura

            Console.WriteLine($"Vendedor: {venda.Vendedor}, Valor: {venda.Valor}, Comissão: {comissaoFormatada}");
        }
    }

    public void ExibirResumoVendedores()
    {
        // Agrupando as vendas por vendedor e calculando o total de vendas e comissão para cada vendedor
        var resumoVendedores = Vendas
            .GroupBy(venda => venda.Vendedor)
            .Select(g => new
            {
                Vendedor = g.Key,
                TotalVendas = g.Sum(v => v.Valor),
                TotalComissao = g.Sum(v => v.CalcularComissao())
            })
            .ToList();

        Console.WriteLine("\n========================================================================");
        Console.WriteLine("                    RESUMO CONSOLIDADO POR VENDEDOR                     ");
        Console.WriteLine("========================================================================");
        foreach (var vendedor in resumoVendedores)
        {
            decimal comissao = vendedor.TotalComissao;
            string comissaoFormatada = comissao.ToString("C2", CulturaBR); // Formata a comissão como moeda brasileira (R$) para facilitar a leitura

            Console.WriteLine($"Vendedor: {vendedor.Vendedor}, Valor total: {vendedor.TotalVendas}, Comissão total: {comissaoFormatada}");
        }
    }
}