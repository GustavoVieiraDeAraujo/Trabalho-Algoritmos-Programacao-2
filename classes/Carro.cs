public class Carro{
    
    public int Ano { get; set; }
    public string Cor { get; set; }
    public decimal Preco { get; set; }
    public string Modelo { get; set; }
    public string Fabricante { get; set; }
    public int Quantidade { get; set; } = 0;
    public string TipoCombustivel { get; set; }

    public Carro(
        int ano,
        string cor,
        string modelo,
        decimal preco, 
        string fabricante, 
        string tipoCombustivel
    ){
        Ano = ano;
        Cor = cor;
        Preco = preco;
        Modelo = modelo;
        Fabricante = fabricante;
        TipoCombustivel = tipoCombustivel;
    }
}