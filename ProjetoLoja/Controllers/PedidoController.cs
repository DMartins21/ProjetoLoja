using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProjetoLoja.Models;
using ProjetoLoja.Repository.Interfaces;

namespace ProjetoLoja.Controllers;

public class PedidoController : Controller
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public PedidoController(IPedidoRepository pedidoRepository, ICarrinhoCompraRepository carrinhoCompraRepository,
        CarrinhoCompra carrinhoCompra)
    {
        _pedidoRepository = pedidoRepository;
        _carrinhoCompraRepository = carrinhoCompraRepository;
        _carrinhoCompra = carrinhoCompra;
    }

    [HttpGet]
    public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Pedido pedido)
    {
        pedido.PedidoCriado = DateTime.Now;
        int totalItens = 0;
        decimal precoTotal = 0.0m;

        var itens = _carrinhoCompraRepository.GetCarrinhoCompraItens();
        _carrinhoCompra.CarrinhoCompraItems = itens;

        if (itens.Count == 0)
        {
            ModelState.AddModelError("", "Seu Carrinho está vazio");
        }

        foreach (var item in itens)
        {
            totalItens += item.Quantidade;
            precoTotal += (item.Produto.Preco * item.Quantidade);
        }

        pedido.TotaldeItens = totalItens;
        pedido.TotaldoPedido = precoTotal;

        if (!ModelState.IsValid)
        {
            return View(pedido);
        }

        _pedidoRepository.CriarPedido(pedido);

        ViewBag.CheckoutCompletoMensagem = "Obrigado pelo pedido";
        ViewBag.TotalPedido = _carrinhoCompraRepository.GetCarrinhoCompraTotal();
        _carrinhoCompraRepository.LimparCarrinho();
        return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
    }
}