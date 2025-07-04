using Microsoft.EntityFrameworkCore;
using ProjetoLoja.Context;
using ProjetoLoja.Models;
using ProjetoLoja.Repository.Interfaces;

namespace ProjetoLoja.Repository;

public class CarrinhoCompraRepository : ICarrinhoCompraRepository
{
    private readonly AppDbContext _context;
    private readonly CarrinhoCompraItem _carrinhoCompraItem;
    private readonly CarrinhoCompra _carrinhoCompra;
    public CarrinhoCompraRepository(AppDbContext context)
    {
        _context = context;
    }

    public static CarrinhoCompra GetCarrinhoCompra(IServiceProvider services)
    {
        //define uma sessão
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        
        //obtem um serviço do tipo do nosso contexto
        var context = services.GetService<AppDbContext>();
        
        //obtem ou gera o Id do carrinho
        string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();
        
        //atribui o id do carrinho ma sessão
        session.SetString("CarrinhoId", carrinhoId);
        
        //retorna o carrinho com o contexto e o Id atribuido ou obtido
        return new CarrinhoCompra()
        {
            CarrinhoCompraId = carrinhoId
        };
    }

    public void AdicionarAoCarrinho(Produto produto)
    {
        var carrinhoCompraItem = _context.ItensCarrinho
            .SingleOrDefault(s => s.Produto.IdProduto == produto.IdProduto
            && s.CarrinhoCompraId == _carrinhoCompraItem.CarrinhoCompraId);

        if (carrinhoCompraItem == null)
        {
            carrinhoCompraItem = new CarrinhoCompraItem()
            {
                CarrinhoCompraId = _carrinhoCompraItem.CarrinhoCompraId,
                Produto = produto,
                Quantidade = 1
            };
            _context.SaveChanges();
        }
        else carrinhoCompraItem.Quantidade++;
        _context.SaveChanges();
    }

    public void RemoverdoCarrinho(Produto produto)
    {
        var carrinhoCompraItem = _context.ItensCarrinho
            .SingleOrDefault(s => s.Produto.IdProduto == produto.IdProduto &&
                                  s.CarrinhoCompraId == _carrinhoCompraItem.CarrinhoCompraId);
        
        if (carrinhoCompraItem != null)
            if (carrinhoCompraItem.Quantidade > 1)
                carrinhoCompraItem.Quantidade--;
            else _context.ItensCarrinho.Remove(carrinhoCompraItem);
        
        _context.SaveChanges();
        
    }

    public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
    {
        return  _carrinhoCompra.CarrinhoCompraItems ??
               (_carrinhoCompra.CarrinhoCompraItems =
                   _context.ItensCarrinho
                   .Where(c => c.CarrinhoCompraId == _carrinhoCompraItem.CarrinhoCompraId)
                   .Include(s => s.Produto)
                   .ToList()
               );
    }

    public void LimparCarrinho()
    {
        var carrinhoItens = _context.ItensCarrinho
            .Where(c => c.CarrinhoCompraId == _carrinhoCompraItem.CarrinhoCompraId);
        _context.RemoveRange(carrinhoItens);
        _context.SaveChanges();
    }

    public decimal GetCarrinhoCompraTotal()
    {
       return _context.ItensCarrinho
            .Where(c => c.CarrinhoCompraId == _carrinhoCompraItem.CarrinhoCompraId)
            .Select(c => c.Produto.Preco * c.Quantidade).Sum();
    }
}