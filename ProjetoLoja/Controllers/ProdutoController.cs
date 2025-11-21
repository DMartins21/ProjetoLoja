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
            .Where(p => p.Categoria.NomeCategoria.Equals(categoriaAtual))
            .OrderBy(p => p.NomeProduto);

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

    [HttpGet] 
    public ViewResult Search(string searchString)
    {
        IEnumerable<Produto> produtos;
        var categoriaAtual = string.Empty;

        if(string.IsNullOrEmpty(searchString))
        {
            produtos = _produtoRepository.Produtos.OrderBy(p => p.IdProduto);
            categoriaAtual = "Todas as Categorias";
        }
        else
        {
            produtos = _produtoRepository.Produtos
                .Where(p => p.NomeProduto.ToLower().
                    Contains(searchString.ToLower()));
            
            if(produtos.Any())
            {
                categoriaAtual = "Produtos";
            }

            else
            {
                categoriaAtual = "Nenhum Produto encontrado";
            }
        }
        
        ViewData["searchString"] = searchString;
        
        return View("Index", new ProdutoListViewModel
        {
            Produtos = produtos,
            CategoriaAtual = categoriaAtual
        });
    }
}