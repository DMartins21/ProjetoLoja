using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.Models;
using ProjetoLoja.Repository;
using ProjetoLoja.Repository.Interfaces;
using ProjetoLoja.ViewModel;
using ProjetoLoja.Context;

namespace ProjetoLoja.Controllers;

public class CarrinhoCompraController : Controller
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;
    private readonly CarrinhoCompra _carrinhoCompra;
    
    public CarrinhoCompraController(IProdutoRepository produtoRepository, IServiceProvider serviceProvider)
    {
        _produtoRepository = produtoRepository;
        _carrinhoCompra = CarrinhoCompraRepository.GetCarrinho(serviceProvider);
        var context = serviceProvider.GetRequiredService<AppDbContext>();
        _carrinhoCompraRepository = new CarrinhoCompraRepository(context, _carrinhoCompra);
    }

    public IActionResult Index()
    {
        var carrinho = _carrinhoCompraRepository.GetCarrinhoCompraItens();
        _carrinhoCompra.CarrinhoCompraItems = carrinho;

        var carrinhoCompraVM = new CarrinhoCompraViewModel()
        {
            CarrinhoCompra = _carrinhoCompra,
            ValorTotal = _carrinhoCompraRepository.GetCarrinhoCompraTotal()
        };
        
        return View(carrinhoCompraVM);
    }

    public RedirectToActionResult AddProduto(int produtoId)
    {
        var produto = _produtoRepository.Produtos.FirstOrDefault(p => p.IdProduto == produtoId);
        if(produto is not null) _carrinhoCompraRepository.AdicionarAoCarrinho(produto);
        return RedirectToAction("Index");
    }

    public IActionResult RemoverProduto(int id)
    {
        var produto = _produtoRepository.Produtos.FirstOrDefault( p => p.IdProduto == id);
        if (produto is not null) _carrinhoCompraRepository.RemoverdoCarrinho(produto);
        
        return RedirectToAction("Index");
    }
}