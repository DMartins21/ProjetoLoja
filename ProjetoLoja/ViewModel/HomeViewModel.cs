using ProjetoLoja.Models;

namespace ProjetoLoja.ViewModel;

public class HomeViewModel
{
    public IEnumerable<Produto> ProdutosFavoritos { get; set; }
}