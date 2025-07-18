using Microsoft.EntityFrameworkCore;
using ProjetoLoja.Context;
using ProjetoLoja.Models;
using ProjetoLoja.Repository.Interfaces;

namespace ProjetoLoja.Repository;

public class CarrinhoCompraRepository : ICarrinhoCompraRepository
{
    private readonly AppDbContext  _context;
    private CarrinhoCompra _carrinhoCompra;
    private List<CarrinhoCompraItem> _carrinhoCompraItens;
    
    public CarrinhoCompraRepository(AppDbContext context, CarrinhoCompra carrinhoCompra)
    {
        _context = context;
        _carrinhoCompra = carrinhoCompra;
        _carrinhoCompraItens = new List<CarrinhoCompraItem>();
    }
    
    public static CarrinhoCompra GetCarrinho(IServiceProvider services)
    {
        var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
        
        // var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();
        // var session = httpContextAccessor.HttpContext!.Session;
        
        var context = services.GetRequiredService<AppDbContext>();
        
        var carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();
        
        session.SetString("CarrinhoId", carrinhoId);
        
        return new CarrinhoCompra
        {
            CarrinhoCompraId = carrinhoId
        };
    }

    public void AdicionarAoCarrinho(Produto produto)
    {
        var item = _context.CarrinhoCompraItems
            .SingleOrDefault(p => p.Produto.IdProduto == produto.IdProduto
                                  && p.CarrinhoCompraId == _carrinhoCompra.CarrinhoCompraId);

        if (item is null)
        {
            item = new CarrinhoCompraItem()
            {
                CarrinhoCompraId = _carrinhoCompra.CarrinhoCompraId,
                Produto = produto,
                Quantidade = 1
            };
            _context.CarrinhoCompraItems.Add(item);
        }
        else item.Quantidade++;
        _context.SaveChanges();
    }

    public void RemoverdoCarrinho(Produto produto)
    {
        var carrinho = _context.CarrinhoCompraItems
            .SingleOrDefault(p => p.Produto.IdProduto == produto.IdProduto
            && p.CarrinhoCompraId == _carrinhoCompra.CarrinhoCompraId);
        if (carrinho is not null)
        {
            if (carrinho.Quantidade > 1)
            {
                carrinho.Quantidade--;
            }
            else _context.CarrinhoCompraItems.Remove(carrinho);
        }
        _context.SaveChanges();
    }

    public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
    {
        return _context.CarrinhoCompraItems 
                .Where(c => c.CarrinhoCompraId == _carrinhoCompra.CarrinhoCompraId)
                .Include(p => p.Produto)
                .ToList();
    }
    
    public void LimparCarrinho()
    {
        var carrinhoItens = _context.CarrinhoCompraItems
            .Where(c => c.CarrinhoCompraId == _carrinhoCompra.CarrinhoCompraId);
        _context.RemoveRange(carrinhoItens);
        _context.SaveChanges();
    }

    public decimal GetCarrinhoCompraTotal()
    {
        return _context.CarrinhoCompraItems
            .Where(c => c.CarrinhoCompraId == _carrinhoCompra.CarrinhoCompraId)
            .Select(c => c.Produto.Preco * c.Quantidade).Sum();
    }
}