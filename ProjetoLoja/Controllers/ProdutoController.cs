using Microsoft.AspNetCore.Mvc;
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
    
    public IActionResult Index()
    {
        // var produtos = _produtoRepository.Produtos.ToList();
        // return View(produtos);

        var produtoListViewModel = new ProdutoListViewModel();
        produtoListViewModel.Produtos = _produtoRepository.Produtos;
        produtoListViewModel.CategoriaAtual = "Categoria Atual";
        return View(produtoListViewModel);
    }
}