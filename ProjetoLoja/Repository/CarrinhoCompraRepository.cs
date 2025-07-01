using ProjetoLoja.Context;
using ProjetoLoja.Models;
using ProjetoLoja.Repository.Interfaces;

namespace ProjetoLoja.Repository;

public class CarrinhoCompraRepository : ICarrinhoCompraRepository
{
    private readonly AppDbContext _context;
    private ICarrinhoCompraRepository _carrinhoCompraRepositoryImplementation;
    private ICarrinhoCompraRepository _carrinhoCompraRepositoryImplementation1;

    public CarrinhoCompraRepository(AppDbContext context)
    {
        _context = context;
    }

    public CarrinhoCompra GetCarrinhoCompra(IServiceProvider services)
    {
        //define uma sessão
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        
        //obtem um serviço do tipo do nosso contexto
        var context = services.GetService<AppDbContext>();
        
        //obtem ou gera o Id do carrinho
        string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();
        
        //atribui o id do carrinho ma sessão
        session.SetString("CarrinhoId", carrinhoId);
        
        //retorna o carrinho com o contexto e o Id atribuido ou obtido
        return new CarrinhoCompra()
        {
            CarrinhoCompraId = carrinhoId
        };
    }
}