# 🎯 Teste Técnico - Desenvolvimento C# / .NET

Este repositório contém a resolução dos 3 desafios propostos para o teste técnico de desenvolvimento da Target Sistemas. As soluções foram construídas utilizando C# e .NET, focando em boas práticas de Programação Orientada a Objetos (POO).

---

## Tecnologias Utilizadas

- **Linguagem:** C# / .NET (10.0)
- **Biblioteca de Serialização:** `System.Text.Json`
- **Consultas e Agregações:** LINQ (*Language Integrated Query*)
- **Internacionalização:** `System.Globalization` (Formatação em moeda brasileira `pt-BR`)

## Descrição dos Desafios

### Questão 1 — Cálculo de Comissões
Lê as vendas de `vendas.json`, calcula a comissão de cada venda e apresenta os valores por vendedor. Vendas abaixo de R$ 100,00 não geram comissão; vendas de R$ 100,00 a menos de R$ 500,00 geram 1%; vendas a partir de R$ 500,00 geram 5%.

### Questão 2 — Movimentação de Estoque
Carrega os produtos de `estoque.json` e permite registrar entradas e saídas informando produto, quantidade e descrição. Cada movimentação recebe um identificador sequencial, atualiza o estoque em memória e exibe a quantidade final do produto.

### Questão 3 — Cálculo de Juros
Recebe o valor de uma cobrança e sua data de vencimento, calcula os dias de atraso até hoje e aplica juros simples de 2,5% ao dia. Exibe o valor dos juros e o total atualizado.

---

## Estrutura da Solução

O projeto está organizado em uma única Solution (`.sln`), dividida em três projetos distintos:

```text
MeuTesteTecnico/
├── src/
│   ├── Questao1.CalculoComissao/            # Teste 1: Leitura do JSON e cálculo de comissões
│   ├── Questao2.LancarMovimetacaoEstoque/   # Teste 2: Gestão de entradas e saídas de estoque
│   └── Questao3.CalculoJuros/               # Teste 3: Cálculo de multa/juros por atraso
├── TesteTecnico.slnx
└── README.md

```

##  Como Executar os Projetos

### Pré-requisitos
.NET SDK instalado (versão 10.0 ou superior).

### Passos no Terminal

Clone o repositório:
```
    git clone https://github.com/LuizHenri16/Desafio-TargetSistemas.git
    cd DesafioTargetSistemas
```

Para executar a Questão 1 (Comissões):
```
    cd src/Questao1.CalculoComissao
    dotnet run
```

Para executar a Questão 2 (Estoque):
```
    cd src/Questao2.LancarMovimetacaoEstoque
    dotnet run
```

Para executar a Questão 3 (Juros):
```
    cd src/Questao3.CalculoJuros
    dotnet run
```

Para voltar a pasta principal:
``` 
    cd .. 
```