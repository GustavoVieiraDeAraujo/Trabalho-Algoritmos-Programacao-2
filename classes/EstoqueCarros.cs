using System;
using System.Globalization;

public class EstoqueCarros {

    private Carro[] carros;
    private Database database;
    private int quantidadeCarrosEstoque = 0;
    private const int quantidadeMaximaCarrosEstoque = 1000;

    public EstoqueCarros() {
        this.database = new Database();

        Carro[] carrosCarregados = this.database.CarregarCarros();
        this.carros = carrosCarregados.Length > 0 ? carrosCarregados : new Carro[0];

        for (int i = 0; i < carrosCarregados.Length; i++) {
            this.carros[i] = carrosCarregados[i];
            quantidadeCarrosEstoque += carrosCarregados[i].Quantidade;
        }

        return;
    }

    private void AdicionarCarroVetor(Carro novoCarro) {
        int novoTamanho = this.carros.Length + 1;
        Carro[] novoVetor = new Carro[novoTamanho];

        for (int i = 0; i < this.carros.Length; i++) {
            novoVetor[i] = this.carros[i];
        }

        novoVetor[novoTamanho - 1] = novoCarro;
        this.carros = novoVetor;
    }

    private void RemoverCarroPelaPosicaoVetor(int posicao) {
        int novoTamanho = this.carros.Length - 1;
        Carro[] novoVetor = new Carro[novoTamanho];

        for (int i = 0; i < posicao; i++) {
            novoVetor[i] = this.carros[i];
        }

        for (int i = posicao + 1; i < this.carros.Length; i++) {
            novoVetor[i - 1] = this.carros[i];
        }

        this.carros = novoVetor;
    }

    public void AdicionarCarro() {
        int ano = LerValidaValidaEntradas.LerValidaAno();
        string cor = LerValidaValidaEntradas.LerValidaCor();
        decimal preco = LerValidaValidaEntradas.LerValidaPreco();
        string modelo = LerValidaValidaEntradas.LerValidaModelo();
        string fabricante = LerValidaValidaEntradas.LerValidaFabricante();
        string tipoCombustivel = LerValidaValidaEntradas.LerValidaTipoCombustivel();

        Carro carro = new Carro(ano, cor, modelo, preco, fabricante, tipoCombustivel);

        AdicionarCarroVetor(carro);
        
        this.database.SalvarCarro(carro);

        Console.WriteLine($"\nCarro '{modelo}' adicionado com sucesso!");
        return;
    }

    public bool ListarCarros() {
        if (this.carros.Length == 0) {
            Console.WriteLine("\nNenhum carro no estoque.");
            return false;
        }

        Console.WriteLine("Lista de Carros:\n");
        foreach (Carro carro in this.carros) {
            Console.WriteLine(carro);
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Ano: {carro.Ano} \nCor: {carro.Cor} \nModelo: {carro.Modelo} \nPreço: {carro.Preco} \nQuantidade em estoque: {carro.Quantidade} \nTipo de Combustivel: {carro.TipoCombustivel}");
            Console.WriteLine("-----------------------------------------");
        }
        return true;
    }

    public void RemoverCarro() {
        Console.Write("\nInforme o modelo do carro a ser removido: ");
        string modeloCarro = Console.ReadLine();

        for (int i = 0; i < this.carros.Length; i++) {

            if (this.carros[i].Modelo.Equals(modeloCarro, StringComparison.OrdinalIgnoreCase)) {

                Carro carroRemovido = this.carros[i];

                if ((quantidadeCarrosEstoque - carroRemovido.Quantidade) >= 0) {
                    quantidadeCarrosEstoque -= carroRemovido.Quantidade;
                } else {
                    Console.WriteLine($"\nNão é possível remover a quantidade informada!");
                    return;
                }

                RemoverCarroPelaPosicaoVetor(i);

                this.database.RemoverCarro(carroRemovido.Modelo);
                Console.WriteLine($"\nCarro '{carroRemovido.Modelo}' removido com sucesso!");
                return;
            }
        }

        Console.WriteLine($"Carro do modelo '{modeloCarro}' não encontrado!");
    }

    public void EntradaEstoque() {
        Console.Write("\nInforme o modelo do carro para entrada de estoque: ");
        string modeloCarro = Console.ReadLine();

        for (int i = 0; i < this.carros.Length; i++) {
            if ( this.carros[i].Modelo.Equals(modeloCarro, StringComparison.OrdinalIgnoreCase) ) {
                Console.Write("\nInforme a quantidade de entrada: ");
                int quantidade = Convert.ToInt32(Console.ReadLine());

                if ( (quantidadeCarrosEstoque + quantidade) <= quantidadeMaximaCarrosEstoque && quantidade > 0 ){
                    this.carros[i].Quantidade += quantidade;
                    quantidadeCarrosEstoque += quantidade;

                    this.database.SalvarCarro(this.carros[i]);
                    Console.WriteLine($"\nEntrada de {quantidade} unidade(s) no estoque do carro '{this.carros[i].Modelo}'.");
                    return;

                } else {

                    Console.WriteLine("\nInsira uma quantidade válida!");
                    return;

                }

                return;
            }
        }

        Console.WriteLine("\nModelo de carro não encontrado!");
    }

    public void SaidaEstoque() {
        Console.Write("\nInforme o modelo do carro para saída de estoque: ");
        string modeloCarro = Console.ReadLine();

        for (int i = 0; i < this.carros.Length; i++) {
            if (this.carros[i].Modelo.Equals(modeloCarro, StringComparison.OrdinalIgnoreCase)) {
                Console.Write("\nInforme a quantidade de saída: ");
                int quantidade = Convert.ToInt32(Console.ReadLine());

                if ((quantidadeCarrosEstoque - quantidade) >= 0 && (this.carros[i].Quantidade - quantidade) >= 0 && quantidade > 0) {
                    this.carros[i].Quantidade -= quantidade;
                    quantidadeCarrosEstoque -= quantidade;

                    this.database.SalvarCarro(this.carros[i]);
                    Console.WriteLine($"\nSaída de {quantidade} unidade(s) do carro '{this.carros[i].Modelo}'.");
                } else {
                    Console.WriteLine($"\nEstoque insuficiente para o carro '{this.carros[i].Modelo}'.");
                }
                return;
            }
        }

        Console.WriteLine("\nCarro não encontrado!");
    }
}