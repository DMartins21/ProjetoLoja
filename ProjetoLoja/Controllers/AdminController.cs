using Microsoft.AspNetCore.Mvc;

namespace ProjetoLoja.Controllers;

public class AdminController : Controller
{
    public string Index()
    {
        return "Teste de Rotas";
    }
}