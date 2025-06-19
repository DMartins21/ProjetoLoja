using ProjetoLoja.Models;

namespace ProjetoLoja.Repository.Interfaces;

public interface ICategoriaRepository
{
   IEnumerable<Categoria> Categorias { get; }
}