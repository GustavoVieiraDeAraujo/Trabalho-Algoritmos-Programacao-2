using System;
using System.Threading;

public static class LerValidaValidaEntradas {

    public static string LerValidaModelo(){
        string modelo;

        do{
            Console.Write("Informe o modelo do carro: ");
            modelo = Console.ReadLine();
            Console.Clear();
            
            if (string.IsNullOrWhiteSpace(modelo)) {
                Console.WriteLine("\nInsira um modelo, não deixe em branco!\n");
                Thread.Sleep(1500);
                Console.Clear();
            }

        } while (string.IsNullOrWhiteSpace(modelo));

        return modelo;
    }


    public static decimal LerValidaPreco(){
        decimal preco;

        while (true){
            Console.Write("Informe o preço do carro (R$): ");

            if (decimal.TryParse(Console.ReadLine(), out preco) && preco > 0){
                Console.Clear();
                break;
            }

            Console.WriteLine("\nPreço inválido. Insira um valor positivo e decimal.\n");
            Thread.Sleep(1500);
            Console.Clear();
        }

        return preco;
    }

    public static string LerValidaFabricante(){
        string fabricante;

        do{
            Console.Write("Informe a fabricante: ");
            fabricante = Console.ReadLine();
            Console.Clear();

            if (string.IsNullOrWhiteSpace(fabricante)){
                Console.WriteLine("\nInsira uma fabricante, não deixe em branco!\n");
                Thread.Sleep(1500);
                Console.Clear();
            }

        } while (string.IsNullOrWhiteSpace(fabricante));
        
        return fabricante;
    }

    public static int LerValidaAno(){
        int ano;
        int anoAtual = DateTime.Now.Year;
        
        while (true){
            Console.Write("Informe o ano de fabricação: ");
            // O valor 1886 foi decidido baseado no ano que o primeiro carro surgiu.
            if (int.TryParse(Console.ReadLine(), out ano) && ano >= 1886 && ano <= anoAtual){
                Console.Clear();
                break;
            }
            Console.WriteLine($"\nAno inválido. Insira um valor entre 1886 e {anoAtual}.\n");
            Thread.Sleep(1500);
            Console.Clear();
        }

        return ano;
    }

    public static string LerValidaCor(){
        string cor;

        do{
            Console.Write("Informe a cor do carro: ");
            cor = Console.ReadLine();
            Console.Clear();

            if (string.IsNullOrWhiteSpace(cor)){
                Console.WriteLine("\nInsira uma cor, não deixe em branco!\n");
                Thread.Sleep(1500);
                Console.Clear();
            }

        } while (string.IsNullOrWhiteSpace(cor));

        return cor;
    }

    public static string LerValidaTipoCombustivel(){
        string tipoCombustivel;
        
        do{
            Console.Write("Informe o tipo de combustível: ");
            tipoCombustivel = Console.ReadLine();
            Console.Clear();

            if (string.IsNullOrWhiteSpace(tipoCombustivel)){
                Console.WriteLine("\nInsira um tipo de combustivel, não deixe em branco!\n");
                Thread.Sleep(1500);
                Console.Clear();
            }

        } while (string.IsNullOrWhiteSpace(tipoCombustivel));

        return tipoCombustivel;
    }
}
