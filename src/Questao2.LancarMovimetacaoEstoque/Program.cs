
// Executável principal do Programa.
try
{
    var estoqueService = new EstoqueService("estoque.json");
    bool executando = true;

    while (executando)
    {
        Console.Clear();
        Console.WriteLine("=== Sistema de Movimentação de Estoque ===");
        ExibirEstoqueAtual(estoqueService);

        Console.WriteLine("\n[1] Lançar Entrada / Saída");
        Console.WriteLine("[0] Sair");
        Console.Write("\nEscolha uma opção: ");
    
    string opcao = Console.ReadLine() ?? "";

    switch (opcao)
        {
            case "1":
                LancarMovimentacao(estoqueService);
                break;
            case "0":
                executando = false;
                break;
            default:
                ExibirErro("Opção inválida!");
                break;
        }

    }

} catch (Exception ex)
{
    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
}


/*
    Esse método é responsável por lançar uma movimentação de estoque, seja de entrada ou saída.
    Ele solicita ao usuário o código do produto, tipo de movimentação, quantidade e descrição/motivo da movimentação.
    Em seguida, chama o método RegistrarMovimentacao do EstoqueService para processar a movimentação.
    Caso a movimentação seja registrada com sucesso, exibe uma mensagem de sucesso e o estoque final do produto.
    Caso ocorra algum erro, exibe uma mensagem de erro detalhando o problema.
 */
static void LancarMovimentacao(EstoqueService service)
{
    Console.WriteLine("\n--- LANÇAR MOVIMENTAÇÃO ---");

    Console.Write("Código do Produto: ");
    if (!int.TryParse(Console.ReadLine(), out int codigo))
    {
        ExibirErro("Código inválido!");
        return;
    }

    Console.Write("Tipo de Movimentação (1 - Entrada | 2 - Saída): ");
    if (!Enum.TryParse(Console.ReadLine(), out TipoMovimentacao tipo) || !Enum.IsDefined(tipo))
    {
        ExibirErro("Tipo de movimentação inválido!");
        return;
    }

    Console.Write("Quantidade: ");
    if (!int.TryParse(Console.ReadLine(), out int quantidade))
    {
        ExibirErro("Quantidade inválida!");
    return;
    }

    Console.Write("Descrição/Motivo da Movimentação: ");
    string descricao = Console.ReadLine() ?? "";

    var resultado = service.RegistrarMovimentacao(codigo, tipo, quantidade, descricao);

    if (resultado.Sucesso)
    {
        Console.ForegroundColor = ConsoleColor.Green; // Só para diferenciar a mensagem de sucesso da de erro.
        Console.WriteLine($"\n-> {resultado.Mensagem}");
        Console.WriteLine($"-> ESTOQUE FINAL DO PRODUTO: {resultado.EstoqueFinal} unidades");
        Console.ResetColor();
    }
    else
    {
        ExibirErro(resultado.Mensagem);
    }
    
    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}


void ExibirEstoqueAtual (EstoqueService service)
{
    Console.WriteLine("\n=== Estoque Atual ===");
    Console.WriteLine($"{"Código",-8} | {"Descrição do Produto",-30} | {"Estoque Atual",-15}");
    Console.WriteLine("------------------------------------------------------------------------");
    
    foreach (var p in service.ListarProdutos())
    {
        Console.WriteLine($"{p.CodigoProduto,-8} | {p.DescricaoProduto,-30} | {p.Estoque,15}");
    }
}

static void ExibirErro(string mensagem)
{
    Console.ForegroundColor = ConsoleColor.Red; // Só para diferenciar a mensagem de erro da de sucesso.
    Console.WriteLine($"\n✗ Erro: {mensagem}");
    Console.ResetColor();
    Console.WriteLine("Pressione qualquer tecla para continuar...");
    Console.ReadKey();
}

