using ProjetoLoja.Context;
using ProjetoLoja.Models;
using ProjetoLoja.Repository.Interfaces;

namespace ProjetoLoja.Repository;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;
    private readonly CarrinhoCompraRepository _carrinhoCompraRepository;
    
    public PedidoRepository(AppDbContext context, CarrinhoCompraRepository carrinhoCompraRepository)
    {
        _context = context;
        _carrinhoCompraRepository = carrinhoCompraRepository;
    }
    
    public void CriarPedido(Pedido pedido)
    {
        pedido.PedidoCriado = DateTime.Now;
        _context.Pedidos.Add(pedido);
        _context.SaveChanges();

        var itensCarrinho = _carrinhoCompraRepository.GetCarrinhoCompraItens();

        foreach (var itens in itensCarrinho)
        {
            var OrderDatails = new PedidoDetalhe()
            {
                Quantidade = itens.Quantidade,
                ProdutoId = itens.Produto.IdProduto,
                PedidoId = pedido.PedidoId,
                Preco = itens.Produto.Preco
            };
            _context.PedidoDetalhes.Add(OrderDatails);
        }
        _context.SaveChanges();
    }
}