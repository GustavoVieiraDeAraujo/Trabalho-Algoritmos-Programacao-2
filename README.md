# Controle de Estoque de Carros

Projeto da disciplina **Algoritmos e Programacao II** do Senac EAD ([enunciado](./docs/Enunciado.pdf)). Sistema de controle de estoque de carros com interface CLI e persistencia em SQLite, implementado em C# (.NET 6.0).

---

## Sumario

- [Participantes](#participantes)
- [Tecnologias](#tecnologias)
- [Escopo do Projeto](#escopo-do-projeto)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Requisitos](#requisitos)
- [Como Executar](#como-executar)
- [Funcionalidades](#funcionalidades)
- [Arquitetura](#arquitetura)
- [Demonstracao](#demonstracao)

---

## Participantes

| Nome                              | Matricula |
|-----------------------------------|-----------|
| Gustavo Vieira de Araujo          | 211068440 |

---

## Tecnologias

| Tecnologia         | Uso                                                     |
|--------------------|---------------------------------------------------------|
| C# / .NET 6.0     | Linguagem e runtime                                     |
| SQLite             | Banco de dados local para persistencia do estoque        |
| System.Data.SQLite | Driver SQLite para .NET                                  |

---

## Escopo do Projeto

| Requisito da disciplina                                    | Implementacao                                                        |
|------------------------------------------------------------|----------------------------------------------------------------------|
| Classe do produto com nome, preco, quantidade + 3 atributos| `Carro` com 7 atributos (modelo, preco, quantidade, ano, cor, fabricante, tipoCombustivel) |
| Quantidade inicia em zero                                  | `Quantidade { get; set; } = 0`                                       |
| Menu: Novo, Listar, Remover, Entrada, Saida, Sair         | Menu recursivo em `Main.cs` com 6 opcoes                              |
| TAD (Tipo Abstrato de Dado) para controle de estoque       | `EstoqueCarros` — array dinamico com operacoes de CRUD                |
| Validacao de entradas do usuario                           | `LerValidaEntradas` — validacao de ano, preco, strings obrigatorias   |
| Video de demonstracao (1 minuto)                           | `video-execucao-codigo.mkv`                                          |
| **Extra:** persistencia com banco de dados                 | SQLite via `DatabaseService` (spec pedia apenas em memoria)           |

---

## Estrutura do Projeto

| Diretorio / Arquivo           | Descricao                                                           |
|-------------------------------|---------------------------------------------------------------------|
| `Program.cs`                  | Ponto de entrada — menu CLI recursivo com 6 opcoes                   |
| `Models/Carro.cs`             | Entidade Carro com 7 propriedades (ano, cor, preco, modelo, fabricante, quantidade, tipoCombustivel) |
| `Services/EstoqueCarros.cs`   | TAD — adicionar, listar, remover carros e gerenciar entrada/saida de estoque |
| `Services/DatabaseService.cs` | Camada de persistencia — CRUD com SQLite (CREATE, INSERT OR REPLACE, SELECT, DELETE) |
| `Utils/LerValidaEntradas.cs`  | Validacao de entradas (ano entre 1886 e atual, preco positivo, strings nao vazias) |
| `controle_estoque.csproj`     | Projeto .NET 6.0 com dependencia System.Data.SQLite                  |
| `docs/Enunciado.pdf`          | Especificacao do trabalho                                            |
| `docs/video-execucao-codigo.mkv` | Video de demonstracao do programa em execucao                     |

---

## Requisitos

- .NET 6.0 SDK

```bash
# Ubuntu/Debian
sudo apt install dotnet-sdk-6.0

# Ou via script oficial
curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 6.0
```

---

## Como Executar

```bash
dotnet restore
dotnet run
```

O banco SQLite (`db/estoque.db`) e criado automaticamente na primeira execucao.

---

## Funcionalidades

| Opcao | Comando             | Descricao                                                  |
|-------|----------------------|------------------------------------------------------------|
| 1     | Adicionar Carro      | Cadastra um novo carro com validacao de todos os campos     |
| 2     | Listar Carros        | Exibe todos os carros com seus atributos e quantidade       |
| 3     | Remover Carro        | Remove um carro pelo modelo                                 |
| 4     | Entrada Estoque      | Adiciona unidades ao estoque de um carro (limite: 1000)     |
| 5     | Saida Estoque        | Remove unidades do estoque (valida saldo disponivel)        |
| 0     | Sair                 | Encerra o programa                                          |

---

## Arquitetura

O projeto segue o padrao de separacao em camadas:

```
Program.cs (interface CLI)
    |
    v
Services/EstoqueCarros (TAD — logica de negocio)
    |
    +--- Models/Carro (entidade de dados)
    +--- Utils/LerValidaEntradas (validacao de input)
    +--- Services/DatabaseService (persistencia SQLite)
```

- **`Carro`** — classe com 7 propriedades e construtor
- **`EstoqueCarros`** — TAD que gerencia um array dinamico de carros, redimensionado manualmente (sem List/ArrayList) para atender ao requisito de implementar a estrutura de dados
- **`LerValidaEntradas`** — metodos estaticos de validacao com loop ate entrada valida
- **`DatabaseService`** — CRUD com SQLite usando `INSERT OR REPLACE` para upsert por modelo

---

## Demonstracao

O arquivo [`video-execucao-codigo.mkv`](./docs/video-execucao-codigo.mkv) contem a gravacao do programa em execucao demonstrando todas as funcionalidades (adicionar, listar, entrada/saida de estoque, remover e sair).
