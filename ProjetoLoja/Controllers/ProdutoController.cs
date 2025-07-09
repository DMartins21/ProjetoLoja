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
        string categoriaAtual = string.Empty;
        
            switch (categoria)
            {
                case "Eletronicos":
                    produtos = _produtoRepository.Produtos
                        .Where(p => p.Categoria.NomeCategoria.Equals("Eletrônicos"))
                        .OrderBy(p => p.NomeProduto);
                    break;
                case "Roupas":
                    produtos = _produtoRepository.Produtos
                        .Where(p => p.Categoria.NomeCategoria.Equals("Roupas"))
                        .OrderBy(p => p.NomeProduto);
                    break;
                case "Livros":
                    produtos = _produtoRepository.Produtos
                        .Where(p => p.Categoria.NomeCategoria.Equals("Livros"))
                        .OrderBy(p => p.NomeProduto);
                    break;
                case "Alimentos":
                    produtos = _produtoRepository.Produtos
                        .Where(p => p.Categoria.NomeCategoria.Equals("Alimentos"))
                        .OrderBy(p => p.NomeProduto);
                    break;
                default:
                    return NotFound("Categoria não encontrada");
            }

            categoriaAtual = categoria;


        var produtoListViewModel = new ProdutoListViewModel
        {
            Produtos = produtos,
            CategoriaAtual = categoriaAtual
        };
        return View(produtoListViewModel);
    }
}