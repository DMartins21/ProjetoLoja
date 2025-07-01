namespace ProjetoLoja.Models;

public class CarrinhoCompra
{
    public string CarrinhoCompraId {get; set;}
    public List<CarrinhoCompraItem> CarrinhoCompraItems {get; set;}
}