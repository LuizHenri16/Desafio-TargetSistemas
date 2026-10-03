using System.Text.Json.Serialization;

public class Estoque
{
    [JsonPropertyName("estoque")]
    public List<Produto> Produtos { get; set; } = new();

}