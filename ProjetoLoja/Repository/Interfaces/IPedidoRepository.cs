using ProjetoLoja.Models;

namespace ProjetoLoja.Repository.Interfaces;

public interface IPedidoRepository
{
    void CriarPedido(Pedido pedido);
}