using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.Models;
using ProjetoLoja.Repository;
using ProjetoLoja.ViewModel;

namespace ProjetoLoja.Components;

public class CarrinhoCompraResumo : ViewComponent
{
    private readonly CarrinhoCompra _carrinhoCompra;
    private readonly CarrinhoCompraRepository _carrinhoCompraRepository;

    public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra, CarrinhoCompraRepository carrinhoCompraRepository)
    {
        _carrinhoCompra = carrinhoCompra;
        _carrinhoCompraRepository = carrinhoCompraRepository;
    }

    public IViewComponentResult Invoke()
    {
        var carrinho = _carrinhoCompraRepository.GetCarrinhoCompraItens();
        _carrinhoCompra.CarrinhoCompraItems = carrinho;
        var carrinhoCompraVm = new CarrinhoCompraViewModel()
        {
            CarrinhoCompra = _carrinhoCompra,
            ValorTotal = _carrinhoCompraRepository.GetCarrinhoCompraTotal()
        };
        
        return View(carrinhoCompraVm);
    }
}
