using ProjetoLoja.Models;

namespace ProjetoLoja.Repository.Interfaces;

public interface ICarrinhoCompraRepository
{
    CarrinhoCompra GetCarrinhoCompra(IServiceProvider services);
}