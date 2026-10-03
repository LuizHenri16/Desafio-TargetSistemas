using System.Text.Json.Serialization;

public class Venda
{
    [JsonPropertyName("vendedor")]
    public string Vendedor { get; set; } = string.Empty;
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    public decimal CalcularComissao()
    {
        if (Valor < 100)
        {
            return 0;
        }
        else if (Valor < 500)
        {
            // Comissão para valores entre R$100 e R$499 é 1%
            // Arredondando para 2 casas decimais, arredondando para cima se o valor estiver no meio
            return decimal.Round(Valor * 0.01m, 2, MidpointRounding.AwayFromZero); 
            }
        else
        {
            // Comissão para valores de R$500 ou mais é 5%
            // Arredondando para 2 casas decimais, arredondando para cima se o valor estiver no meio
            return decimal.Round(Valor * 0.05m, 2, MidpointRounding.AwayFromZero); 
        }
    }
    
}