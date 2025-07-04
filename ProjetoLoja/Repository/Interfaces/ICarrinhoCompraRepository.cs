using ProjetoLoja.Models;

namespace ProjetoLoja.Repository.Interfaces;

public interface ICarrinhoCompraRepository
{
    public static abstract CarrinhoCompra GetCarrinhoCompra(IServiceProvider services);
}