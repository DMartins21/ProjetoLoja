using ProjetoLoja.Models;

namespace ProjetoLoja.Repository.Interfaces;

public interface ICarrinhoCompraRepository
{
    List<CarrinhoCompraItem> GetCarrinhoCompraItens();
    void AdicionarAoCarrinho(Produto produto);
    void RemoverdoCarrinho(Produto produto);
    decimal GetCarrinhoCompraTotal();
}