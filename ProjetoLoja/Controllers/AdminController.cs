using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoLoja.Controllers;
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    public string Index()
    {
        return "Teste de Rotas";
    }
}