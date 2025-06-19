using ProjetoLoja.Models;

namespace ProjetoLoja.Repository.Interfaces;

public interface IProdutoRepository
{
    IEnumerable<Produto> Produtos { get; }
    
    IEnumerable<Produto> ProdutosPreferidos { get; }
    
    Produto GetProdutoById(int produtoid);
}