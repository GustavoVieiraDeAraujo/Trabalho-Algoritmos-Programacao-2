
using System;


class Program {

    public static void Main(string[] args) {
        bool temCarros = false;
        EstoqueCarros estoque = new EstoqueCarros();

        while (true) {
            Console.Clear();
            Console.WriteLine("CONTROLE DE ESTOQUE DE CARROS");
            Console.WriteLine("\n[1] Adicionar Carro");
            Console.WriteLine("[2] Listar Carros");
            Console.WriteLine("[3] Remover Carro");
            Console.WriteLine("[4] Adicionar Estoque de um Carro");
            Console.WriteLine("[5] Remover Estoque de um Carro");
            Console.WriteLine("[0] Sair do Sistema");

            Console.Write("\nEscolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao) {

                case "1":
                    Console.Clear();
                    estoque.AdicionarCarro();
                    break;

                case "2":
                    Console.Clear();
                    temCarros = estoque.ListarCarros();
                    break;

                case "3":
                    Console.Clear();
                    temCarros = estoque.ListarCarros();
                    if (temCarros) { estoque.RemoverCarro();}
                    break;

                case "4":
                    Console.Clear();
                    temCarros = estoque.ListarCarros();
                    if (temCarros) {estoque.EntradaEstoque();}
                    break;

                case "5":
                    Console.Clear();
                    temCarros = estoque.ListarCarros();
                    if (temCarros) {estoque.SaidaEstoque();}
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
