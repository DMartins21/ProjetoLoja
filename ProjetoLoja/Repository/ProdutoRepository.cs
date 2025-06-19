using Microsoft.EntityFrameworkCore;
using ProjetoLoja.Context;
using ProjetoLoja.Repository.Interfaces;
using ProjetoLoja.Models;

namespace ProjetoLoja.Repository;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Produto> Produtos => _context.Produtos
        .Include(c => c.Categoria);
    
    public IEnumerable<Produto> ProdutosPreferidos => _context.Produtos
        .Where(p => p.Favorito)
        .Include(c => c.Categoria);

    public Produto GetProdutoById(int produtoid) => _context.Produtos.FirstOrDefault(p => p.IdProduto == produtoid);
}