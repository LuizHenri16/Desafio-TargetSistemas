public class EstoqueService
{

    private readonly List<Produto> _produtos = new();
    private readonly List<Movimentacao> _movimentacoes = new();
    private int _nextMovimentacaoId = 1;


    public EstoqueService( string caminhoJson)
    {
        CarregarDadosInicio(caminhoJson);
    }

    /* Método para carregar os dados do estoque a partir de um arquivo JSON.
        Recebe o caminho do arquivo JSON como parâmetro.
        Caso o arquivo não seja encontrado, lança uma exceção FileNotFoundException.
        Caso o arquivo seja encontrado, lê o conteúdo e desserializa para a lista de produtos.
    */ 
    public void CarregarDadosInicio(string json)
    {
        // Carrega os dados do estoque a partir do json fornecido no documento do desafio.
        if(!File.Exists(json))
        {
            // Indo no principio de fail fast, onde caso o arquivo não seja encontrado, o sistema deve falhar imediatamente.
            throw new FileNotFoundException($"Arquivo {json} não encontrado.");
        }

        // Lê o conteúdo do arquivo JSON e desserializa para a lista de produtos.
        string estoque = File.ReadAllText(json);
        var dadosEstoque = System.Text.Json.JsonSerializer.Deserialize<Estoque>(estoque);
        
        // Com o contúdo lido, adiciono os produtos na lista de produtos do serviço.
        if (dadosEstoque != null)
        {
            _produtos.AddRange(dadosEstoque.Produtos);
        }
    }

    // Usado para listar os produtos disponíveis no estoque.
    public IEnumerable<Produto> ListarProdutos()
    {
        return _produtos;
    }


    /*  Método para registrar a movimentação de estoque, retornando uma tupla com sucesso, mensagem e estoque final.
        É recebido o código do produto, tipo de movimentação e quantidade
        Ocorre as verificações necessárias para validar a movimentação, como se o produto existe, se a quantidade é válida e se há estoque.
        Caso passe em todas, o estoque do produto é atualizado e a movimentação é registrada na lista de movimentações. 
    */
    public (bool Sucesso, string Mensagem, int EstoqueFinal) RegistrarMovimentacao (
            int codigoProduto, 
            TipoMovimentacao tipo, 
            int quantidade, 
            string descricao)
    {

        var produto = _produtos.FirstOrDefault(p => p.CodigoProduto == codigoProduto);
        if (produto == null)
        {
            return (false, $"Produto com código {codigoProduto} não encontrado.", 0);
        }

        if (quantidade <= 0)
        {
            return (false, "A quantidade deve ser maior que zero.", produto.Estoque);
        }

        if (tipo == TipoMovimentacao.Saida && produto.Estoque < quantidade)
        {
            return (false, $"Estoque insuficiente para o produto {produto.DescricaoProduto}. Estoque atual: {produto.Estoque}.", produto.Estoque);
        }

        if (tipo == TipoMovimentacao.Entrada)
        {   produto.Estoque += quantidade;
        } else
        {
           produto.Estoque -= quantidade;
        }

        var movimentacao = new Movimentacao
        {
            Id = _nextMovimentacaoId++,
            CodigoProduto = codigoProduto,
            Tipo = tipo,
            Quantidade = quantidade,
            Descricao = descricao
        };

        _movimentacoes.Add(movimentacao);

        return (true, $"Movimentação #{movimentacao.Id} registrada com sucesso!", produto.Estoque); // Retorna uma tupla indicando sucesso, mensagem e estoque final.
    }
}