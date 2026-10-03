# 🎯 Teste Técnico - Desenvolvimento C# / .NET

Este repositório contém a resolução dos 3 desafios propostos para o teste técnico de desenvolvimento da Target Sistemas. As soluções foram construídas utilizando C# e .NET, focando em boas práticas de Programação Orientada a Objetos (POO).

---

## Tecnologias Utilizadas

- **Linguagem:** C# / .NET (10.0)
- **Biblioteca de Serialização:** `System.Text.Json`
- **Consultas e Agregações:** LINQ (*Language Integrated Query*)
- **Internacionalização:** `System.Globalization` (Formatação em moeda brasileira `pt-BR`)

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
    cd seu-repositorio
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