using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FlowAnalysis;
using ProjetoLoja.Models;
using ProjetoLoja.Repository.Interfaces;
using ProjetoLoja.ViewModel;

namespace ProjetoLoja.Controllers;

public class ProdutoController : Controller
{
    public readonly IProdutoRepository _produtoRepository;

    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public IActionResult Index(string categoria)
    {
        IEnumerable<Produto> produtos;
        var categoriaAtual = string.Empty;

        if (string.IsNullOrEmpty(categoria))
        {
            produtos = _produtoRepository.Produtos
                .OrderBy(p => p.IdProduto);
            categoriaAtual = "Todas as Categorias";
        }
        
        else produtos = _produtoRepository.Produtos
            .Where(c => c.Categoria.NomeCategoria.Equals(categoria))
            .OrderBy(c => c.NomeProduto);

            categoriaAtual = categoria;


        var produtoListViewModel = new ProdutoListViewModel
        {
            Produtos = produtos,
            CategoriaAtual = categoriaAtual
        };
        return View(produtoListViewModel);
    }

    public IActionResult Details(int idProduto)
    {
        var produto = _produtoRepository.Produtos.FirstOrDefault(p => p.IdProduto == idProduto);
        if (produto == null) return NotFound();
        return View(produto);
    }
}